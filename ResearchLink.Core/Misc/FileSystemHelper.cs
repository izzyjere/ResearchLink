using ResearchLink.Core.Services.Impl;

namespace ResearchLink.Core.Misc
{
    [Service]
    internal class FileSystemHelper : IFileSystemHelper
    {
        public string ReadAsBlob(FileModel fileModel)
        {

            var finalPath = Path.Combine(Environment.CurrentDirectory, "Files", fileModel.FileStore.ToString() + fileModel.Path);
            if (File.Exists(finalPath))
            {
                try
                {
                    var fileBytes = File.ReadAllBytes(finalPath);
                    var base64String = Convert.ToBase64String(fileBytes);
                    var mimeType = fileModel.ContentType;
                    var dataUrl = $"data:{mimeType};base64,{base64String}";
                    return dataUrl;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            throw new InvalidOperationException("File not found in the source.");
        }

        public  FileModel Upload(MemoryStream memoryStream, string contentType, FileStore fileStore)
        {
            var root = Path.Combine(Environment.CurrentDirectory, "Files", fileStore.ToString());
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var path = GetRandomFileStructure()+Guid.NewGuid().ToString().Substring(0, 8).Replace("-", "_") + ".rlink";
            var filePath = Path.Combine(root + path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
            memoryStream.WriteTo(fileStream);
            fileStream.Close();
            return new FileModel
            {
                ContentType = contentType,
                Path = path,
                FileStore = fileStore,
            };
        }

        string GetRandomFileStructure()
        {
            var random = new Random();
            var randomDepth = random.Next(1, 5);
            var randomFolderName = "\\";
            for (int i = 0; i < randomDepth; i++)
            {
                randomFolderName += $"{Guid.NewGuid().ToString().Substring(0, 8)}\\";
            }
            return randomFolderName;
        }
    }
}
