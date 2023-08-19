namespace ResearchLink.Core.Misc;

public interface IFileSystemHelper
{
    string ReadAsBlob(FileModel fileModel);
    Task RunFileStoreCleanUp();
    FileModel? Upload(MemoryStream memoryStream, string contentType, FileStore fileStore);
}
