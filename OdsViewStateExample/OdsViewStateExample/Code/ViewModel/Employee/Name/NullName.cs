using System;

namespace OdsViewStateExample
{
    [Serializable]
    public sealed class NullName : Name
    {
        public override string FirstName
        {
            get
            {
                return string.Empty;
            }
        }

        public override string LastName
        {
            get
            {
                return string.Empty;
            }
        }
    }
}