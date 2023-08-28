using Microsoft.Extensions.Logging;

using ResearchLink.Core.Services.Impl;

namespace ResearchLink.Core.Misc
{
    [Service]
    internal class FileSystemHelper : IFileSystemHelper
    {
        static string FileStoreRoot = Path.Combine(Environment.CurrentDirectory, "Files");
        readonly ILogger<FileSystemHelper> _logger;
        readonly DatabaseContext _databaseContext;
        public FileSystemHelper(ILogger<FileSystemHelper> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
            if(!Directory.Exists(FileStoreRoot))
            {
                _logger.LogInformation("Creating FileStore Root..");
                Directory.CreateDirectory(FileStoreRoot);
            }
        }
        public string ReadAsBlob(FileModel fileModel)
        {

            var finalPath = Path.Combine(FileStoreRoot, fileModel.FileStore.ToString() + fileModel.Path);
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
        bool FileIsCleanable(string fileName)
        {
            var filePresent = _databaseContext.Set<Author>().Select(a=>a.Avatar).Any(f=>f.FileName==fileName);
            var filePresent2 = _databaseContext.Set<Research>().Select(a=>a.Document).Any(f=>f.FileName==fileName);
           return !filePresent && !filePresent2;
        }   
        public async Task RunFileStoreCleanUp()
        {
            _logger.LogInformation($"Filestore cleanup triggered at {DateTime.Now:dd/MM/yyy H:mm:ss}");
            var mainFileStoreFiles = GetFilesRecursive(FileStoreRoot);
            _logger.LogInformation("Found: {0} files in main store", mainFileStoreFiles.Count);
            var mainCleaner = Task.Run(() =>
            {
                foreach (var filePath in mainFileStoreFiles)
                {
                    var fileName = Path.GetFileName(filePath);
                    if (fileName!=null && FileIsCleanable(fileName))
                    {
                        File.Delete(filePath);
                        _logger.LogInformation("Cleaned Up: {0}", filePath);
                    }
                }
            });
            await mainCleaner;
        }

        public  FileModel? Upload(MemoryStream memoryStream, string contentType, FileStore fileStore)
        {
            try
            {
                var root = Path.Combine(FileStoreRoot, fileStore.ToString());
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
                _logger.LogInformation($"File uploaded to {filePath}");
                return new FileModel
                {
                    ContentType = contentType,
                    Path = path,
                    FileStore = fileStore,
                    FileName = Path.GetFileName(filePath)
                };
            }
            catch (Exception e)
            {   
                e.PrintStackTrace();
                return null;                
            }             
        }
        public static List<string> GetFilesRecursive(string directory)
        {
            List<string> fileList = new List<string>();
            HashSet<string> addedFiles = new HashSet<string>();

            try
            {
                // Process files in the current directory
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    if (!addedFiles.Contains(file))
                    {
                        fileList.Add(file);
                        addedFiles.Add(file);
                    }
                }

                // Recursively process subdirectories
                string[] subdirectories = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectories)
                {
                    fileList.AddRange(GetFilesRecursive(subdirectory));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.Message}");
            }

            return fileList;
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
