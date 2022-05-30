namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple5Tests: ITestClass {
	
		private readonly World tupleWorld;

		public Tuple5Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple5Arity_shouldBeFive() {
			testMethod("Test if Tuple5 has arity 5");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple5.of(r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(5, "Aritiy of Tuple5 should be 5");
		}


		[TestMethod]
		public void test_maxArityOfTuple5_shouldBeNine() {
			testMethod("Test if Tuple5.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple5.of(r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple5 should be 9");
		}
		
		
		[TestMethod]
		public void test_tuple5_hasCorrectValues() {
			testMethod("Test if Tuple5 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple5.of(12, 34, 56, 78, 90));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple5 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple5 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple5 value #3 should be 56")
					.and.the.FourthTupleValueIsEqualTo(78, "Tuple5 value #4 should be 78")
					.and.the.FifthTupleValueIsEqualTo(90, "Tuple5 value #5 should be 90");
		}

	}

}
