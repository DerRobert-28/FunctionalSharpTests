namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class NullPointerExceptionTests: ITestClass {

		private const string reason = "Test Automation: NullPointerException";
		private readonly World nullPointerWorld;

		public NullPointerExceptionTests() => nullPointerWorld = new World();


		[TestMethod]
		public void test_NullPointerException_shouldeBeThrown() {
			testMethod(reason);

			Arrange
				.theWorld(nullPointerWorld)
				.withLogging(this)
				.withException(NullPointerException.because(reason))
				.withReason(reason)
				.withType(typeof(NullPointerException));

			Act
				.inWorld(nullPointerWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(nullPointerWorld)
				.withLogging(this)
				.That
					.AnyExceptionIsThrown("Expected exception has not been thrown.")
					.ExceptionTypeIsNotNull("No exception type has been defined.");
		}


		[TestMethod]
		public void test_NullPointerExceptionType_shouldBeCorrect() {
			testMethod(reason);

			Arrange
				.theWorld(nullPointerWorld)
				.withLogging(this)
				.withException(NullPointerException.because(reason))
				.withReason(reason)
				.withType(typeof(NullPointerException));

			Act
				.inWorld(nullPointerWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(nullPointerWorld)
				.withLogging(this)
				.That
					.AnyExceptionIsThrown("Expected exception has not been thrown.")
					.GenericExceptionTypeEqualTo(
						typeof(NullPointerException),
						"Exception type should be 'NullPointerException'.");
		}


		[TestMethod]
		public void test_ExceptionReason_shouldBeCorrect() {
			testMethod(reason);

			Arrange
				.theWorld(nullPointerWorld)
				.withLogging(this)
				.withException(NullPointerException.because(reason))
				.withReason(reason)
				.withType(typeof(NullPointerException));

			Act
				.inWorld(nullPointerWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(nullPointerWorld)
				.withLogging(this)
				.That
					.AnyExceptionIsThrown("Expected exception has not been thrown.")
					.ExceptionReasonIsEqualTo(reason, $"Exception reason should be \"{reason}\".");
		}
		
	}

}
