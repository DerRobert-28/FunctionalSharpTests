namespace DerRobert.FunctionalSharpTests.Tests.Interfaces {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;


	[TestClass]
	public class Tuple7Tests: TestClass {
	
		private readonly World tupleWorld;

		public Tuple7Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple7Arity_shouldBeSeven() {
			testMethod("Test if Tuple7 has arity 7");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple7.of(r, r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(7, "Aritiy of Tuple7 should be 7");
		}

		
		[TestMethod]
		public void test_maxArityOfTuple7_shouldBeNine() {
			testMethod("Test if Tuple7.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple7.of(r, r, r, r, r, r, r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple7 should be 9");
		}
	

		[TestMethod]
		public void test_tuple7_hasCorrectValues() {
			testMethod("Test if Tuple7 contains the right values");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple7.of(12, 34, 56, 78, 90, "AB", "CD"));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple7 value #1 should be 12")
					.and.the.SecondTupleValueIsEqualTo(34, "Tuple7 value #2 should be 34")
					.and.the.ThirdTupleValueIsEqualTo(56, "Tuple7 value #3 should be 56")
					.and.the.FourthTupleValueIsEqualTo(78, "Tuple7 value #4 should be 78")
					.and.the.FifthTupleValueIsEqualTo(90, "Tuple7 value #5 should be 90")
					.and.the.SixthTupleValueIsEqualTo("AB", "Tuple7 value #6 should be 'AB'")
					.and.the.SeventhTupleValueIsEqualTo("CD", "Tuple7 value #7 should be 'CD'");
		}

	}

}
