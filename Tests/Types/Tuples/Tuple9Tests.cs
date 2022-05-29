namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple9Tests: TestClass {
	
		private readonly World tupleWorld;

		public Tuple9Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple9Arity_shouldBeNine() {
			testMethod("Test if Tuple9 has arity 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple9.of(r, r, r, r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(9, "Aritiy of Tuple9 should be 9");
		}


		[TestMethod]
		public void test_maxArityOfTuple9_shouldBeNine() {
			testMethod("Test if Tuple9.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple9.of(r, r, r, r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple9 should be 9");
		}


		[TestMethod]
		public void test_tuple9_hasCorrectValues() {
			testMethod("Test if Tuple9 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple9.of(12, 34, 56, 78, 90, "AB", "CD", "EF", "GH"));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple9 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple9 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple9 value #3 should be 56")
					.and.the.FourthTupleValueIsEqualTo(78, "Tuple9 value #4 should be 78")
					.and.the.FifthTupleValueIsEqualTo(90, "Tuple9 value #5 should be 90")
					.and.the.SixthTupleValueIsEqualTo("AB", "Tuple9 value #6 should be 'AB'")
					.and.the.SeventhTupleValueIsEqualTo("CD", "Tuple9 value #7 should be 'CD'")
					.and.the.EighthTupleValueIsEqualTo("EF", "Tuple9 value #8 should be 'EF'")
					.and.the.NinthTupleValueIsEqualTo("GH", "Tuple9 value #9 should be 'GH'");
		}

	}

}
