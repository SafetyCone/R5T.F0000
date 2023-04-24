using System;

using R5T.T0132;
using R5T.T0140;


namespace R5T.F0000.Construction
{
	[FunctionalityMarker]
	public partial interface ITypeOperations : IFunctionalityMarker
	{
		public void ShowFullName()
        {
			// System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e],[System.Int32, System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
			var type = typeof(System.Collections.Generic.KeyValuePair<string, int>);

			Console.WriteLine(type.FullName);
        }

		public void IsConstructed()
        {
			this.IsConstructedGeneric_ForOpenGeneric();
			this.IsConstructedGeneric_ForClosedGeneric();
			this.IsConstructedGeneric_ForPartiallyClosedGeneric();
        }

		public void IsCostructedGeneric_ForNonGeneric()
        {
			var type = Instances.ExampleTypes.NonGeneric;

			var isConstructed = Instances.TypeOperator.IsConstructedGeneric(type);

			Console.WriteLine($"{isConstructed}: Is constructed generic type?\n{type.FullName}");
		}

		public void IsConstructedGeneric_ForPartiallyClosedGeneric()
		{
			var partiallyConstructedType = Instances.ExampleTypes.PartiallyConstructedType;

			var isConstructed = Instances.TypeOperator.IsConstructedGeneric(partiallyConstructedType);

			Console.WriteLine($"{isConstructed}: Is constructed generic type?\n{partiallyConstructedType.FullName}");
		}

		public void IsConstructedGeneric_ForClosedGeneric()
		{
			var type = Instances.ExampleTypes.ClosedGeneric;

			var isConstructed = Instances.TypeOperator.IsConstructedGeneric(type);

			Console.WriteLine($"{isConstructed}: Is constructed generic type?\n{type.FullName}");
		}

		public void IsConstructedGeneric_ForOpenGeneric()
		{
			var type = Instances.ExampleTypes.ClosedGeneric;

			var isConstructed = Instances.TypeOperator.IsConstructedGeneric(type);

			Console.WriteLine($"{isConstructed}: Is constructed generic type?\n{type.FullName}");
		}

		public void IsClosedGeneric()
		{
			this.IsClosedGeneric_ForOpenGeneric();
			this.IsClosedGeneric_ForClosedGeneric();
			this.IsClosedGeneric_ForPartiallyClosedGeneric();
		}

		public void IsClosedGeneric_ForPartiallyClosedGeneric()
		{
			var partiallyConstructedType = Instances.ExampleTypes.PartiallyConstructedType;

			var isClosed = Instances.TypeOperator.IsClosedGeneric(partiallyConstructedType);

			Console.WriteLine($"{isClosed}: Is closed generic type?\n{partiallyConstructedType.FullName}");
		}

		public void IsClosedGeneric_ForClosedGeneric()
		{
			var type = Instances.ExampleTypes.ClosedGeneric;

			var isClosed = Instances.TypeOperator.IsClosedGeneric(type);

			Console.WriteLine($"{isClosed}: Is closed generic type?\n{type.FullName}");
		}

		public void IsClosedGeneric_ForOpenGeneric()
		{
			var type = Instances.ExampleTypes.OpenGenericClass;

			var isClosed = Instances.TypeOperator.IsClosedGeneric(type);

			Console.WriteLine($"{isClosed}: Is closed generic type?\n{type.FullName}");
		}

		public void IsOpenGeneric()
        {
			this.IsOpenGeneric_ForOpenGeneric();
			this.IsOpenGeneric_ForClosedGeneric();
			this.IsOpenGeneric_ForPartiallyClosedGeneric();
        }

		public void IsOpenGeneric_ForPartiallyClosedGeneric()
		{
			// Make a partially-closed
			var partiallyConstructedType = Instances.ExampleTypes.PartiallyConstructedType;

			var isOpen = Instances.TypeOperator.IsOpenGeneric(partiallyConstructedType);

			Console.WriteLine($"{isOpen}: Is open generic type?\n{partiallyConstructedType.FullName}");
		}

		public void IsOpenGeneric_ForClosedGeneric()
		{
			var type = Instances.ExampleTypes.ClosedGeneric;

			var isOpen = Instances.TypeOperator.IsOpenGeneric(type);

			Console.WriteLine($"{isOpen}: Is open generic type?\n{type.FullName}");
		}

		public void IsOpenGeneric_ForOpenGeneric()
        {
			var type = Instances.ExampleTypes.OpenGenericClass;

			var isOpen = Instances.TypeOperator.IsOpenGeneric(type);

			Console.WriteLine($"{isOpen}: Is open generic type?\n{type.FullName}");
		}

		public void IsGeneric_ForClosedGeneric()
		{
			var type = Instances.ExampleTypes.ClosedGeneric;

			var isGeneric = Instances.TypeOperator.IsGeneric(type);

			Console.WriteLine($"{isGeneric}: Is generic type?\n{type.FullName}");
		}

		public void IsGeneric_ForOpenGeneric()
        {
			var type = Instances.ExampleTypes.OpenGenericClass;

			var isGeneric = Instances.TypeOperator.IsGeneric(type);

			Console.WriteLine($"{isGeneric}: Is generic type?\n{type.FullName}");
        }
	}
}