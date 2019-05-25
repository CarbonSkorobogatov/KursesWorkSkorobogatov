using System.Collections.Generic;

namespace ProxSenceProject.Models.Interfaces
{
    public interface IOrderProcesser
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
