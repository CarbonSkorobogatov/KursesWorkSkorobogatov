using System.Collections.Generic;
using ProxSenceProject.Models.Interfaces;

namespace ProxSenceProject.Models.EntityFramework
{
    public class EFHome : INewsData 
    {
        private EFHomeDbContext _context;
        public EFHome(EFHomeDbContext context)
        {
            _context = context;
        }
        public IEnumerable<News> NewsData => _context.NewsData;
    }
}
