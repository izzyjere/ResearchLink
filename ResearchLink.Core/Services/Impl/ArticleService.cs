using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ArticleService : ServiceBase<Article>, IArticleService
    {
        public ArticleService(DatabaseContext context) : base(context)
        {
        }
    }

}
