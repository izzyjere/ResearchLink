using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Extensions;

public static class HelperExtensions
{
    public static void PrintStackTrace(this Exception exception) => Console.WriteLine(exception.Message + exception.StackTrace);

}
