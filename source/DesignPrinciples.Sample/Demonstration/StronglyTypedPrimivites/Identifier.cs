namespace DesignPrinciples.Sample.Demonstration.StronglyTypedPrimivites
{
    using System;

    public class Identifier
    {
        public Identifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException("Expected identifier but found <null> or <empty>");
            }

            this.Value = identifier;
        }

        public string Value { get; private set; }

        public static implicit operator Identifier(string identifier)
        {
            return new Identifier(identifier);
        }

        public static implicit operator string(Identifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            return identifier.Value;
        }

        public static bool operator ==(Identifier a, Identifier b)
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

        public static bool operator !=(Identifier a, Identifier b)
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

            return this.Equals((Identifier)obj);
        }

        public override int GetHashCode()
        {
            return this.Value != null ? this.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.Value;
        }

        private bool Equals(Identifier other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            return string.Equals(this.Value, other.Value);
        }
    }
}