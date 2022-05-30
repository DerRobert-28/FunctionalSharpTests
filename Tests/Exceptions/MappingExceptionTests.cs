namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using DerRobert.FunctionalSharpTests.Core;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class MappingExceptionTests: TestClass {

		private const string reason = "Test Automation: MappingException";
		private readonly World mappingWorld;

		public MappingExceptionTests() => mappingWorld = new World();


		[TestMethod]
		public void test_MappingException_shouldeBeThrown() {
			testMethod(reason);

			Arrange
				.theWorld(mappingWorld)
				.withLogging(this)
				.withException(MappingException.because(reason))
				.withReason(reason)
				.withType(typeof(MappingException));

			Act
				.inWorld(mappingWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(mappingWorld)
				.withLogging(this)
				.That
					.AnyExceptionIsThrown("Expected exception has not been thrown.")
					.ExceptionTypeIsNotNull("No exception type has been defined.");
		}


		[TestMethod]
		public void test_MappingExceptionType_shouldBeCorrect() {
			testMethod(reason);

			Arrange
				.theWorld(mappingWorld)
				.withLogging(this)
				.withException(MappingException.because(reason))
				.withReason(reason)
				.withType(typeof(MappingException));

			Act
				.inWorld(mappingWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(mappingWorld)
				.withLogging(this)
				.That
					.AnyExceptionIsThrown("Expected exception has not been thrown.")
					.GenericExceptionTypeEqualTo(
						typeof(MappingException),
						"Exception type should be 'MappingException'.");
		}


		[TestMethod]
		public void test_ExceptionReason_shouldBeCorrect() {
			testMethod(reason);

			Arrange
				.theWorld(mappingWorld)
				.withLogging(this)
				.withException(MappingException.because(reason))
				.withReason(reason)
				.withType(typeof(MappingException));

			Act
				.inWorld(mappingWorld)
				.withLogging(this)
				.throwException();

			Expect
				.forWorld(mappingWorld)
				.withLogging(this)
				.That
					.AnyExceptionIsThrown("Expected exception has not been thrown.")
					.ExceptionReasonIsEqualTo(reason, $"Exception reason should be \"{reason}\".");
		}
		
	}

}
