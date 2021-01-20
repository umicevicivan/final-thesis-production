using System;
using System.Collections.Generic;
using System.Text;

namespace Production.Domen
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfessionalName { get; set; }
        public string Shape { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public double Price { get; set; }
        public int UnitOfMeasureID { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public static implicit operator List<object>(Product v)
        {
            throw new NotImplementedException();
        }
    }
}
