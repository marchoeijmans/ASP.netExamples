using System;

namespace OdsViewStateExample
{
    [Serializable]
    public class EmployeeViewModel
    {
        private static readonly NullEmployeeViewModel _nullEmployee = new NullEmployeeViewModel();

        public EmployeeViewModel()
        {
            if (null == Name)
                Name = new Name();
            if (null == Address)
                Address = new Address();
        }

        public virtual int ID { get; set; }

        public virtual Name Name { get; set; }

        public virtual Address Address { get; set; }

        public EmployeeViewModel Select()
        {
            return this;
        }

        public void Add(EmployeeViewModel employeeToAdd)
        {
            if (employeeToAdd.IsValid)
            {
                ID = employeeToAdd.ID;
                Name.FirstName = employeeToAdd.Name.FirstName;
                Name.LastName = employeeToAdd.Name.LastName;
                Address.Street = employeeToAdd.Address.Street;
                Address.HouseNumber = employeeToAdd.Address.HouseNumber;
            }
            else
            {
                throw new ArgumentException("Parameter for adding employee is not valid");
            }
        }

        public void Remove(EmployeeViewModel employeeToRemove)
        {
            ID = 0;
            Name = Name.Null;
            Address = Address.Null; ;
        }

        public void Update(EmployeeViewModel employeeToUpdate)
        {
            if (employeeToUpdate.IsValid)
            {
                ID = employeeToUpdate.ID;
                Name.FirstName = employeeToUpdate.Name.FirstName;
                Name.LastName = employeeToUpdate.Name.LastName;
                Address.Street = employeeToUpdate.Address.Street;
                Address.HouseNumber = employeeToUpdate.Address.HouseNumber;
            }
            else
            {
                throw new ArgumentException("Parameter for updating employee is not valid");
            }
        }

        public static NullEmployeeViewModel Null
        {
            get { return _nullEmployee; }
        }

        public override string ToString()
        {
            return string.Format("ID = {0}, Name = {1}, Address: {2}",
                ID,
                Name.ToString(),
                Address.ToString());
        }

        public override bool Equals(object obj)
        {
            // Null parameter Guard
            if (obj == null)
            {
                return false;
            }

            // Cast Guard
            EmployeeViewModel viewModel = obj as EmployeeViewModel;
            if ((System.Object)viewModel == null)
            {
                return false;
            }

            return (this.ID == viewModel.ID) && (this.Name == viewModel.Name) && (this.Address == viewModel.Address);
        }

        public bool IsValid
        {
            get
            {
                return (this != null) && (this.Name.IsValid) && (this.Address.IsValid);
            }
        }
    }
}