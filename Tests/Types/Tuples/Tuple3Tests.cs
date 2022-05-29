namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple3Tests: TestClass {
	
		private readonly World tupleWorld;

		public Tuple3Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple3Arity_shouldBeThree() {
			testMethod("Test if Tuple3 has arity 3");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple3.of(r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(3, "Aritiy of Tuple3 should be 3");
		}


		[TestMethod]
		public void test_maxArityOfTuple3_shouldBeNine() {
			testMethod("Test if Tuple3.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple3.of(r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple3 should be 9");
		}


		[TestMethod]
		public void test_tuple3_hasCorrectValues() {
			testMethod("Test if Tuple3 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple3.of(12, 34, 56));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple3 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple3 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple3 value #3 should be 56");
		}

	}

}
