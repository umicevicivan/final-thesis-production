using System;
using System.Collections.Generic;
using System.Text;

namespace Production.Domen.DTOs
{
    public class PlanItemDTO
    {
        public int Id { get; set; }
        public int AnnualProductionPlanId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
    }
}
