namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple4Tests: ITestClass {
	
		private readonly World tupleWorld;

		public Tuple4Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple4Arity_shouldBeFour() {
			testMethod("Test if Tuple4 has arity 4");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple4.of(r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(4, "Aritiy of Tuple4 should be 4");
		}


		[TestMethod]
		public void test_maxArityOfTuple4_shouldBeNine() {
			testMethod("Test if Tuple4.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple4.of(r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple4 should be 9");
		}
		

		[TestMethod]
		public void test_tuple4_hasCorrectValues() {
			testMethod("Test if Tuple4 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple4.of(12, 34, 56, 78));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple4 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple4 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple4 value #3 should be 56")
					.and.the.FourthTupleValueIsEqualTo(78, "Tuple4 value #4 should be 78");
		}

	}

}
