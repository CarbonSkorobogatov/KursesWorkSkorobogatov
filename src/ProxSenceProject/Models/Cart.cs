using System.Collections.Generic;
using System.Linq;

namespace ProxSenceProject.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Project project, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Project.ProjectId == project.ProjectId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Project = project,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Project project) =>
            lineCollection.RemoveAll(l => l.Project.ProjectId == project.ProjectId);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Project.ProjectPrice * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Project Project { get; set; }
        public int Quantity { get; set; }
    }
}