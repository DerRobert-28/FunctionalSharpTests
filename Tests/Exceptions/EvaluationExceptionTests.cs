namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	

	[TestClass]
	public class EvaluationExceptionTests: Exceptions {
	
		private const string reason = "Test Automation: EvaluationException";
		private readonly World evaluationWorld;

		public EvaluationExceptionTests() => evaluationWorld = new World();
		

		[TestMethod]
		public void test_EvaluationException_shouldeBeThrown() {
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
		public void test_EvaluationExceptionType_shouldBeCorrect() {
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
					.genericExceptionTypeEqualTo(
						typeof(EvaluationException),
						"Exception type should be 'EvaluationException'.");
		}


		[TestMethod]
		public void test_ExceptionReason_shouldBeCorrect() {
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
					.exceptionReasonEqualTo(reason, $"Exception reason should be \"{reason}\".");
		}

	}

}
