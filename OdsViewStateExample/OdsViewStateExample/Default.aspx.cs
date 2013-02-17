using System;
using System.Web.UI.WebControls;

namespace OdsViewStateExample
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly string _viewStateKey = "Employee";
        private readonly string _nameKeyInModel = "Name";
        private readonly string _addressKeyInModel = "Address";

        private EmployeeViewModel _employee
        {
            get
            {
                EmployeeViewModel employee = ViewState[_viewStateKey] as EmployeeViewModel;

                if (null == employee)
                    return EmployeeViewModel.Null;
                else
                    return ViewState[_viewStateKey] as EmployeeViewModel;
            }
            set
            {
                ViewState[_viewStateKey] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Make sure the page starts in edit mode with an empty object
            if (!IsPostBack)
            {
                _employee = new EmployeeViewModel();
                EmployeeView.ChangeMode(FormViewMode.Insert);
            }
        }

        protected void OdsEmployeeViewModel_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            // Binds the object stored in the viewstate to the object datasource
            e.ObjectInstance = _employee;
        }

        protected void btrnShowViewState_Click(object sender, EventArgs e)
        {
            lblViewState.Text = _employee.ToString();
        }

        protected void EmployeeView_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            // After inserting the item is displayed
            EmployeeView.ChangeMode(FormViewMode.ReadOnly);
        }

        protected void EmployeeView_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            // After deleting a new item can be inserted
            EmployeeView.ChangeMode(FormViewMode.Insert);
        }

        protected void EmployeeView_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            // Only a single object can be bind to the datasource, for complex / layered object the objects must be created
            // before they can be used by the object datasource.
            // The objectdatasource works with object, not with separate values.
            e.Values[_nameKeyInModel] = CreateInsertedNameObject();
            e.Values[_addressKeyInModel] = CreateInsertedAddressObject();
        }

        protected void EmployeeView_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues[_nameKeyInModel] = CreateEdittedNameObject();
            e.NewValues[_addressKeyInModel] = CreateEdittedAddressObject();
        }

        private Name CreateInsertedNameObject()
        {
            Name nameToInsert;

            try
            {
                TextBox firstName = (TextBox)EmployeeView.FindControl(NameInsertFields.FirstName);
                TextBox lastName = (TextBox)EmployeeView.FindControl(NameInsertFields.LastName);
                nameToInsert = new Name(firstName.Text, lastName.Text);
            }
            catch (Exception)
            {
                nameToInsert = Name.Null;

                // Log exception
            }
            return nameToInsert;
        }

        private Name CreateEdittedNameObject()
        {
            Name nameToEdit;

            try
            {
                TextBox firstName = (TextBox)EmployeeView.FindControl(NameEditFields.FirstName);
                TextBox lastName = (TextBox)EmployeeView.FindControl(NameEditFields.LastName);
                nameToEdit = new Name(firstName.Text, lastName.Text);
            }
            catch (Exception)
            {
                nameToEdit = Name.Null;

                // Log exception
            }

            return nameToEdit;
        }

        private Address CreateInsertedAddressObject()
        {
            Address addressToInsert;
            try
            {
                TextBox street = (TextBox)EmployeeView.FindControl(AddressInsertFields.Street);
                TextBox houseNumber = (TextBox)EmployeeView.FindControl(AddressInsertFields.HouseNumber);
                addressToInsert = new Address(street.Text, Convert.ToInt32(houseNumber.Text));
            }
            catch (Exception)
            {
                addressToInsert = Address.Null;

                // Log exception
            }

            return addressToInsert;
        }

        private Address CreateEdittedAddressObject()
        {
            Address addressToEdit;

            try
            {
                TextBox street = (TextBox)EmployeeView.FindControl(AddressEditFields.Street);
                TextBox houseNumber = (TextBox)EmployeeView.FindControl(AddressEditFields.HouseNumber);
                addressToEdit = new Address(street.Text, Convert.ToInt32(houseNumber.Text));
            }
            catch (Exception)
            {
                addressToEdit = null;

                // log excption
            }

            return addressToEdit;
        }
    }
}