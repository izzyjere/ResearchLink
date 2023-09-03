using Azure;

using ResearchLink.Core.Shared;

namespace ResearchLink
{
    public static class PagenationExtensions
    {
        public  static async Task<Page<T>> GetPageAsync<T>(this IQueryable<T> table, PageRequest pageRequest) where T:class, IEntity
        {              
            var count = await table.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageRequest.PageSize);
            var items = await table.OrderByDescending(a => a.CreatedDate).Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize).Take(pageRequest.PageSize).ToListAsync();
            return new Page<T> (table)
            {
                PageNumber = pageRequest.PageNumber,
                TotalPages = totalPages,
                Items = items               
            };
        }
        public  static Page<T> GetPage<T>(this IEnumerable<T> table, PageRequest pageRequest) where T:class, IEntity
        {              
            var count =  table.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageRequest.PageSize);
            var items = table.OrderByDescending(a => a.CreatedDate).Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize).Take(pageRequest.PageSize).ToList();
            return new Page<T> (table)
            {
                PageNumber = pageRequest.PageNumber,
                TotalPages = totalPages,
                Items = items               
            };
        }   
    }
    public class Page<T> where T:class,IEntity
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }
        private IQueryable<T> _query;
        public Page(IQueryable<T> query)
        {
            _query = query;   
        }
        public Page(IEnumerable<T> items)
        {
           _query = items.AsQueryable();
        }
        public Page()
        {
                
        }
        public Page<T> GoToPage(int pageNumber)
        {
            var pageRequest = new PageRequest(pageNumber, 2);
            return _query.GetPage(pageRequest);
        }
    }
    public record PageRequest (int PageNumber,int PageSize);
    public record PageItem (int PageNumber,bool Active);
}
