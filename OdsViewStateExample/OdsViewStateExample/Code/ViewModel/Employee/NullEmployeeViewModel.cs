using System;

namespace OdsViewStateExample
{
    [Serializable]
    public sealed class NullEmployeeViewModel : EmployeeViewModel
    {
        public override int ID
        {
            get
            {
                return 0;
            }
        }

        public override Name Name
        {
            get
            {
                return Name.Null;
            }
        }

        public override Address Address
        {
            get
            {
                return Address.Null;
            }
        }
    }
}