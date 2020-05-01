using System;

namespace WebPlatform.Entities
{
    public class Employee
    {
        public int IDEmployee { get; set; }
        public int IDDocumentType { get; set; }
        public string NameDocumentType { get; set; }
        public string CodeDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public int IDSubArea { get; set; }
        public string NameSubArea { get; set; }
        public int IDArea { get; set; }
        public string NameArea { get; set; }
        public bool Active { get; set; }
        public string URLImage { get; set; }
        public int IDUserCreation { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
