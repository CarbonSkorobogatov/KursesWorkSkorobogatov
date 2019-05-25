using System.Collections.Generic;

namespace ProxSenceProject.Models.Interfaces
{
    public interface INewsData
    {
        IEnumerable<News> NewsData { get; }
    }
}
