namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class Tuple0Tests: TestClass {
	
		private readonly World tupleWorld;

		public Tuple0Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple0Arity_shouldBeZero() {
			testMethod("Test if Tuple0 has arity 0");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple0.of());

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(0, "Aritiy of Tuple0 should be 0");
		}


		[TestMethod]
		public void test_maxArityOfTuple0_shouldBeNine() {
			testMethod("Test if Tuple0.MAX_ARITY is 9");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple0.of());

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple0 should be 9");
		}

	}

}
