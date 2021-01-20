using System;
using System.Collections.Generic;
using System.Text;

namespace Production.Domen
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int JMBG { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string AccountNumber { get; set; }
        public int WorkplaceNumber { get; set; }
        public int OrganizationalUnitNumber { get; set; }

    }
}
