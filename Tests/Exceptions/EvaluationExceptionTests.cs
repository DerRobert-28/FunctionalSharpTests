namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	

	[TestClass]
	public class EvaluationExceptionTests: Exceptions {
	
		private const string reason = "Test Automation: EvaluationException";
		private readonly World evaluationWorld;

		public EvaluationExceptionTests() {
			evaluationWorld = new World();
		}
		
		[TestMethod]
		public void testEvaluationException() {
			testMethod(reason);

			Arrange
				.theWorld(evaluationWorld)
				.withLogging(this)
				.withException(EvaluationException.because(reason))
				.withReason(reason)
				.withType(typeof(EvaluationException));

			Act
				.inWorld(evaluationWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(evaluationWorld)
				.withLogging(this)
				.That
					.anyExceptionIsThrown("Expected exception has not been thrown.")
					.exceptionTypeIsNotNull("No exception type has been defined.");
		}

		[TestMethod]
		public void testEvaluationExceptionTypeShouldBeCorrect() {
			testMethod(reason);
			arrangeException(EvaluationException.because(reason));
			actException();
			assertForExceptionType();
		}

		[TestMethod]
		public void testExceptionMessageShouldBeCorrect() {
			testMethod(reason);

			Arrange
				.theWorld(evaluationWorld)
				.withLogging(this)
				.withException(EvaluationException.because(reason))
				.withReason(reason)
				.withType(typeof(EvaluationException));

			Act
				.inWorld(evaluationWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(evaluationWorld)
				.withLogging(this)
				.That
					.anyExceptionIsThrown("Expected exception has not been thrown.")
					.exceptionReasonEqualTo(reason);
		}

	}

}
