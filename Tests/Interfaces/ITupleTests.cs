namespace DerRobert.FunctionalSharpTests.Tests.Interfaces {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class ITupleTests: TestClass {
	
		private readonly World tupleWorld;

		public ITupleTests() => tupleWorld = new World();


		[TestMethod]
		public void test_maxArity_shouldBeNine() {
			testMethod("Test if MAX_ARITY is equal to 9");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple0.of());

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.MaximumArityEqualTo(9, "Maximum arity of ITuple should be 9");
		}

	}
}
