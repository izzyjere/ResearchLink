using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Misc;

public interface IFileSystemHelper
{
    string ReadAsBlob(FileModel fileModel);
    FileModel Upload(MemoryStream memoryStream, string contentType, FileStore fileStore);
}
