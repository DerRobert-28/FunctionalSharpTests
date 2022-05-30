namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple2Tests: ITestClass {
	
		private readonly World tupleWorld;

		public Tuple2Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple2Arity_shouldBeTwo() {
			testMethod("Test if Tuple2 has arity 2");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple2.of(r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(2, "Arity of Tuple2 should be 2");
		}


		[TestMethod]
		public void test_maxArityOfTuple2_shouldBeNine() {
			testMethod("Test if Tuple2.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple2.of(r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple2 should be 9");
		}


		[TestMethod]
		public void test_tuple2_hasCorrectValues() {
			testMethod("Test if Tuple2 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple2.of(12, 34));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple2 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple2 value #2 should be 34");
		}

	}

}
