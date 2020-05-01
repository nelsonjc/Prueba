namespace WebPlatform.Tests.Biz
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using WebPlatform.Business;
    using WebPlatform.Entities;

    [TestClass]
    public class EmployeeValidatorTest
    {
        [TestMethod]
        public void EmployeeValidateSucces()
        {
            //inicialización
            EmployeeValidatioResult employeeValidatioResult;

            Employee infoEmployee = new Employee
            {

                IDEmployee = 1,
                IDDocumentType = 1,
                NameDocumentType = "Cédula de ciudadanía\r\n",
                CodeDocumentType = "CC",
                DocumentNumber = "123",
                FullName = "123",
                Name = "Juan",
                SecondName = "David",
                Surname = "Peréz",
                SecondSurname = "Zapata",
                IDSubArea = 7,
                NameSubArea = "Control",
                IDArea = 2,
                NameArea = "Administración",
                Active = false,
                URLImage = null,
                IDUserCreation = 1,
                DateCreation = Convert.ToDateTime("2020-04-27T00:00:00")
            };

            //Obtener datos
            employeeValidatioResult = EmployeeValidator.Validate(infoEmployee);

            //Resultado esperado
            Assert.IsTrue(employeeValidatioResult.ISValid);

        }

        [TestMethod]
        public void EmployeeValidateName()
        {
            //inicialización
            EmployeeValidatioResult employeeValidatioResult;

            Employee infoEmployee = new Employee
            {

                IDEmployee = 1,
                IDDocumentType = -1,
                NameDocumentType = "Cédula de ciudadanía\r\n",
                CodeDocumentType = "CC",
                DocumentNumber = "123",
                FullName = "123",
                Name = "",
                SecondName = "David",
                Surname = "",
                SecondSurname = "Zapata",
                IDSubArea = 7,
                NameSubArea = "Control",
                IDArea = 2,
                NameArea = "Administración",
                Active = false,
                URLImage = null,
                IDUserCreation = 1,
                DateCreation = Convert.ToDateTime("2020-04-27T00:00:00")
            };

            //Obtener datos
            employeeValidatioResult = EmployeeValidator.Validate(infoEmployee);

            //Resultado esperado
            Assert.IsFalse(employeeValidatioResult.ISValid);

        }

        [TestMethod]
        public void EmployeeValidateAutocomplete()
        {
            //inicialización
            EmployeeValidatioResult employeeValidatioResult;

            Employee infoEmployee = new Employee
            {
                DocumentNumber = "",
                FullName = ""
            };

            //Obtener datos
            employeeValidatioResult = EmployeeValidator.ValidateAutoComplete(infoEmployee);

            //Resultado esperado
            Assert.IsFalse(employeeValidatioResult.ISValid);
        }
    }
}
