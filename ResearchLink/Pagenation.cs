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
            return new Page<T>
            {
                PageNumber = pageRequest.PageNumber,
                TotalPages = totalPages,
                Items = items               
            };
        }   
    }
    public class Page<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }          
    }
    public record PageRequest (int PageNumber,int PageSize);
    public record PageItem (int PageNumber,bool Active);
}
