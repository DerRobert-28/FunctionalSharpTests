namespace DerRobert.FunctionalSharpTests.Tests.Interfaces {

	using DerRobert.FunctionalSharp.Interfaces;
	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ITupleTests: TestClass {

		[TestMethod]
		public void testMaxArityShouldBeNine() {
			testMethod("Test if MAX_ARITY is available with value of 9");
			ITuple t0 = Tuple0.of();
			assertEquals(t0.MAX_ARITY, 9, "MAX_ARITIY should be 9");
		}

	}
}
