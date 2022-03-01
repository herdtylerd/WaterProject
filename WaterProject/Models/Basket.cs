using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Basket
    {
        // Declare then instantiate - on same line
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Project proj, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault();

            // If the entry isn't in the cart, add it
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            else // If it is already in the cart, update the quantity
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Project proj)
        {
            Items.RemoveAll(x => x.Project.ProjectId == proj.ProjectId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }


        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);
            return sum;
        }

    }


    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Project Project { get; set; }
        public int Quantity { get; set; }
    }
}
