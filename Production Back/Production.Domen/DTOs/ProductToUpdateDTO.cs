using System;
using System.Collections.Generic;
using System.Text;

namespace Production.Domen.DTOs
{
    public class ProductToUpdateDTO
    {
        public string Name { get; set; }
        public string ProfessionalName { get; set; }
        public string Shape { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public double Price { get; set; }
        public int UnitOfMeasureID { get; set; }
        //public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
