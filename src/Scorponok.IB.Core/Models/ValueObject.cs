using System;
using System.Reflection;

namespace Scorponok.IB.Core.Models
{
	public abstract class ValueObject<T> : IEquatable<T>
		where T : ValueObject<T>
	{
		public ValueObject()
		{
			
		}

		public virtual bool Equals(T other)
		{
			if (other == null)
				return false;

			return IsEquals(other);

		}

		private bool IsEquals(T other)
		{
			Type t = GetType();
			Type otherType = other.GetType();

			if (t != otherType)
				return false;

			FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			foreach (FieldInfo field in fields)
			{
				object value1 = field.GetValue(other);
				object value2 = field.GetValue(this);

				if (value1 == null)
				{
					if (value2 != null)
						return false;
				}
				else if (!value1.Equals(value2))
					return false;
			}

			return true;
		}

		//protected ValueObject()
		//{
		//}

		//public override int GetHashCode()
		//{
		//	return base.GetHashCode();
		//}

		//public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
		//{
		//	if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
		//		return true;

		//	if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
		//		return false;

		//	return a.Equals(b);
		//}

		//public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
		//{
		//	return !(a == b);
		//}
	}
}