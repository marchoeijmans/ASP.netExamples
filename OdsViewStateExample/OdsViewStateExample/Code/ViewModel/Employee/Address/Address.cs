using System;

namespace OdsViewStateExample
{
    [Serializable]
    public class Address
    {
        private static NullAddress _nullAddress = new NullAddress();

        public Address()
        {
        }

        public Address(string street, int housenumber)
        {
            this.Street = street;
            this.HouseNumber = housenumber;
        }

        public virtual string Street { get; set; }

        public virtual int HouseNumber { get; set; }

        public static NullAddress Null
        {
            get { return _nullAddress; }
        }

        public override bool Equals(object obj)
        {
            // Null parameter Guard
            if (obj == null)
            {
                return false;
            }

            // Cast Guard
            Address address = obj as Address;
            if ((System.Object)address == null)
            {
                return false;
            }

            return (this.Street == address.Street) && (this.HouseNumber == address.HouseNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Street + " " + this.HouseNumber;
        }

        public bool IsValid
        {
            get
            {
                return (this != Null);
            }
        }
    }
}