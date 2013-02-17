using System;

namespace OdsViewStateExample
{
    [Serializable]
    public sealed class NullAddress : Address
    {
        public override string Street
        {
            get
            {
                return string.Empty;
            }
        }

        public override int HouseNumber
        {
            get
            {
                return 0;
            }
        }
    }
}