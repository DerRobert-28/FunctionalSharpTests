namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple8Tests: ITestClass {
	
		private readonly World tupleWorld;

		public Tuple8Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple8Arity_shouldBeEight() {
			testMethod("Test if Tuple8 has arity 8");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple8.of(r, r, r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(8, "Aritiy of Tuple8 should be 8");
		}


		[TestMethod]
		public void test_maxArityOfTuple8_shouldBeNine() {
			testMethod("Test if Tuple8.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple8.of(r, r, r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple8 should be 9");
		}


		[TestMethod]
		public void test_tuple8_hasCorrectValues() {
			testMethod("Test if Tuple8 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple8.of(12, 34, 56, 78, 90, "AB", "CD", "EF"));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple8 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple8 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple8 value #3 should be 56")
					.and.the.FourthTupleValueIsEqualTo(78, "Tuple8 value #4 should be 78")
					.and.the.FifthTupleValueIsEqualTo(90, "Tuple8 value #5 should be 90")
					.and.the.SixthTupleValueIsEqualTo("AB", "Tuple8 value #6 should be 'AB'")
					.and.the.SeventhTupleValueIsEqualTo("CD", "Tuple8 value #7 should be 'CD'")
					.and.the.EighthTupleValueIsEqualTo("EF", "Tuple8 value #8 should be 'EF'");
		}

	}

}
