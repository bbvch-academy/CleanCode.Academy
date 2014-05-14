namespace DesignPrinciples.Sample.Demonstration.StronglyTypedPrimivites
{
    using System;

    public class OtherType
    {
        public OtherType(string otherType)
        {
            if (string.IsNullOrEmpty(otherType))
            {
                throw new ArgumentException("Expected otherType but found <null> or <empty>");
            }

            this.Value = otherType;
        }

        public string Value { get; private set; }

        public static implicit operator OtherType(string otherType)
        {
            return new OtherType(otherType);
        }

        public static implicit operator string(OtherType otherType)
        {
            if (otherType == null)
            {
                throw new ArgumentNullException("otherType");
            }

            return otherType.Value;
        }

        public static bool operator ==(OtherType a, OtherType b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

// ReSharper disable RedundantCast.0 because otherwise it results in recursion.
            if (((object) a == null) || ((object) b == null))
// ReSharper restore RedundantCast.0
            {
                return false;
            }

            return a.Value == b.Value;
        }

        public static bool operator !=(OtherType a, OtherType b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((OtherType)obj);
        }

        public override int GetHashCode()
        {
            return this.Value != null ? this.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.Value;
        }

        private bool Equals(OtherType other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            return string.Equals(this.Value, other.Value);
        }
    }
}