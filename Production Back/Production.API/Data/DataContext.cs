using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Production.Domen;

namespace Production.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
        public DbSet<PlanItem> PlanItems { get; set; }
        public DbSet<AnnualProductionPlan> AnnualProductionPlans { get; set; }
        public DbSet<Worker> Workers { get; set; }


    }
}
