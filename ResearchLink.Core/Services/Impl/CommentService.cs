using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class CommentService : ServiceBase<Comment>, ICommentService
    {
        public CommentService(DatabaseContext context) : base(context)
        {
        }
    }   
}
