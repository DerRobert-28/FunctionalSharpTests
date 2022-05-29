namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple6Tests: TestClass {
	
		private readonly World tupleWorld;

		public Tuple6Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple6Arity_shouldBeSix() {
			testMethod("Test if Tuple6 has arity 6");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple6.of(r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(6, "Aritiy of Tuple6 should be 6");
		}
		
		
		[TestMethod]
		public void test_maxArityOfTuple6_shouldBeNine() {
			testMethod("Test if Tuple6.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple6.of(r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple6 should be 9");
		}

	
		[TestMethod]
		public void test_tuple6_hasCorrectValues() {
			testMethod("Test if Tuple6 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple6.of(12, 34, 56, 78, 90, "AB"));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple6 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple6 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple6 value #3 should be 56")
					.and.the.FourthTupleValueIsEqualTo(78, "Tuple6 value #4 should be 78")
					.and.the.FifthTupleValueIsEqualTo(90, "Tuple6 value #5 should be 90")
					.and.the.SixthTupleValueIsEqualTo("AB", "Tuple6 value #6 should be 'AB'");
		}

	}

}
