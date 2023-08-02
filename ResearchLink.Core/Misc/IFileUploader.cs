using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Misc;

public interface IFileUploader
{ 
    Task<Result> Upload(MemoryStream memoryStream, string fileName, string contentType);
}
