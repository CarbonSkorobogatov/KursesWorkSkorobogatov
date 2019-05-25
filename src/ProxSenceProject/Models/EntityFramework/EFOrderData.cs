using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ProxSenceProject.Models.Interfaces;

namespace ProxSenceProject.Models.EntityFramework
{
    public class EFOrderData : IOrderProcesser
    {
        private EFDBContext context;
        public EFOrderData(EFDBContext contexting)
        {
            context = contexting;
        }
        public IEnumerable<Order> Orders => context.Orders
            .Include(a => a.Lines)
            .ThenInclude(b => b.Project);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(a => a.Project));
            if(order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
