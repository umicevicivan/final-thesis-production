using System;
using System.Collections.Generic;
using System.Text;

namespace Production.Domen
{
    public class AnnualProductionPlan
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public ICollection<PlanItem> PlanItems { get; set; }

    }
}
