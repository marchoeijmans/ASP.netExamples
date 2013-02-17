using System;

namespace OdsViewStateExample
{
    [Serializable]
    public class Name
    {
        private static NullName _nullName = new NullName();

        public Name()
        {
        }

        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public static NullName Null
        {
            get { return _nullName; }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public override bool Equals(object obj)
        {
            // Null parameter Guard
            if (obj == null)
            {
                return false;
            }

            // Cast Guard
            Name name = obj as Name;
            if ((System.Object)name == null)
            {
                return false;
            }

            return (this.FirstName == name.FirstName) && (this.LastName == name.LastName);
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