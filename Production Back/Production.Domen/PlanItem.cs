using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Production.Domen
{
    public class PlanItem
    {
        public int Id { get; set; }
        public int AnnualProductionPlanId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public AnnualProductionPlan AnnualProductionPlan { get; set; }

    }


}
