namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharpTests.Core;
	using System;


	abstract public class Exceptions: TestClass {

		private string expectedReason = string.Empty;
		private Exception? actualException = null, expectedException = null;
		private Type? expectedType = null;

		
		protected void arrangeException<T>(T exception) where T: Exception {
			testMethod($"<{typeof(T).Name}>");
			expectedReason = exception.Message;
			expectedException = exception;
			expectedType = exception.GetType();
		}

		protected void actException() {
			testMethod();
			Exception? exception = expectedException;
			if(exception == null) {
				testLog("'expectedException' should not be NULL'");
				exception = new NullReferenceException("'expectedException' should not be NULL'");
			}
			testLog("attempt to throw exception");
			try {
				throw exception;
			} catch(Exception e) {
				testLog("caught exception");
				actualException = e;
			}
		}

		protected void assertForAnyException() {
			testMethod();
			string message = "'actualException' should not be NULL";
			if(actualException == null) {
				testLog(message);
				throw new NullReferenceException(message);
			}
		}

		protected void assertForExceptionType() {
			testMethod();
			assertEquals(
				expectedType, actualException?.GetType(),
				$"Exception Type should be \"{expectedType}\".");
		}

		protected void assertForMessage() {
			testMethod();
			assertEquals(
				expectedReason, actualException?.Message,
				$"Message should be \"{expectedReason}\".");
		}

	}

}
