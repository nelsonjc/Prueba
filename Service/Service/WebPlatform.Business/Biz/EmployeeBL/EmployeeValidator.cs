namespace WebPlatform.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebPlatform.Entities;

    public static class EmployeeValidator
    {
        public static EmployeeValidatioResult Validate(Employee employee)
        {
            EmployeeValidatioResult validation = new EmployeeValidatioResult();
            string message = string.Empty;

            if (employee.IDDocumentType <= 0)
                validation.ErrorMessage.Add($"El tipo de documento de identidad es un valor requerido.");

            if (string.IsNullOrEmpty(employee.DocumentNumber))
                validation.ErrorMessage.Add($"El número de documento de identidad es un valor requerido.");

            if (employee == default(Employee))
                validation.ErrorMessage.Add("El Empleado no es valido");

            if (string.IsNullOrEmpty(employee.Name))
                validation.ErrorMessage.Add($"El nombre del Empleado es requerido.");

            if (string.IsNullOrEmpty(employee.Surname))
                validation.ErrorMessage.Add($"El primer apellido del Empleado es requerido.");

            if (employee.IDSubArea <= 0)
                validation.ErrorMessage.Add($"El valor de SubArea es requerido.");

            return validation;
        }

        public static EmployeeValidatioResult ValidateAutoComplete(Employee employee)
        {
            EmployeeValidatioResult validation = new EmployeeValidatioResult();
            string message = string.Empty;

            if (employee == default(Employee))
                validation.ErrorMessage.Add("El Empleado no es valido");


            if (employee != null &&
                (string.IsNullOrEmpty(employee.FullName) && string.IsNullOrEmpty(employee.DocumentNumber)))
                validation.ErrorMessage.Add($"para realizar la búsqueda por Autocomplete se requiere Nombre y/o Número de documento");

            return validation;
        }
    }

    public class EmployeeValidatioResult
    {
        public List<string> ErrorMessage { get; set; } = new List<string>();

        public bool ISValid
        {
            get
            {
                return !ErrorMessage.Any();
            }
        }

        public Error Error
        {
            get
            {
                return new Error(new Exception(), string.Join(Environment.NewLine, ErrorMessage));
            }
        }

    }
}
