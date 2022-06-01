namespace DerRobert.FunctionalSharpTests.Tests.Types.Tuples {

	using DerRobert.FunctionalSharp.Types.Tuples;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;

	[TestClass]
	public class Tuple1Tests: ITestClass {
	
		private readonly World tupleWorld;

		public Tuple1Tests() => tupleWorld = new World();


		[TestMethod]
		public void test_tuple1Arity_shouldBeOne() {
			testMethod("Test if Tuple1 has arity 1");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple1.of(r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.ArityIsEqualTo(1, "Arity of Tuple1 should be 1");
		}
		
		
		[TestMethod]
		public void test_maxArityOfTuple1_shouldBeNine() {
			testMethod("Test if Tuple1.MAX_ARITY is 9");
			int r = new Random().Next();

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple1.of(r));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.MaximumArityEqualTo(9, "Maximum arity of Tuple1 should be 9");
		}


		[TestMethod]
		public void test_tuple1_hasCorrectValue() {
			testMethod("Test if Tuple1 contains the right value");

			Arrange
				.theWorld(tupleWorld)
				.withLogging(this)
				.withTuple(Tuple1.of(12));

			Expect
				.forWorld(tupleWorld)
				.withLogging(this)
				.That
					.the.FirstTupleValueIsEqualTo(12, "Tuple1 value #1 should be 12");
		}

	}

}
