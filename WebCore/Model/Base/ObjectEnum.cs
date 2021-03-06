﻿namespace WebCore.Model.Base
{
    public abstract class ObjectEnum
    {
        internal object Value { get; }
        
        protected ObjectEnum(object value) => Value = value;

        public override string ToString() => Value.ToString();

        public static bool operator == (ObjectEnum a, ObjectEnum b) => a.Value == b.Value;
        public static bool operator != (ObjectEnum a, ObjectEnum b) => a.Value != b.Value;

        public override bool Equals(object obj)
        {
            if (typeof(ObjectEnum).IsAssignableFrom(obj.GetType())) return Value.Equals(((ObjectEnum)obj).Value);

            // it also counts as equal if the object to compare is equal to the object stored in the wrapper
            return Value.Equals(obj);
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
