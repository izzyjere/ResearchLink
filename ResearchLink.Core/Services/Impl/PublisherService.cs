using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Services.Impl;

[Service]
internal class PublisherService : ServiceBase<Publisher>, IPublisherService
{
    public PublisherService(DatabaseContext context) : base(context)
    {
    }
}
