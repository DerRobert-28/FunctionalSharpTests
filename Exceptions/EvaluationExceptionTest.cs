namespace DerRobert.FunctionalSharpTests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class EvaluationExceptionTest: Exceptions {

		[TestMethod("Test of throwing a 'EvaluationException'")]
		public void testEvaluationException() {
			testMethod("Test of throwing a 'EvaluationException'");
			arrangeException(new EvaluationException("throwing EvaluationException"));
			actException();
			assertException();
		}

	}

}
