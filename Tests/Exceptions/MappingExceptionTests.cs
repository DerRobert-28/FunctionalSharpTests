namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class MappingExceptionTests: Exceptions {

		private const string reason = "Test Automation: MappingException";

		[TestMethod]
		public void testMappingException() {
			testMethod(reason);
			arrangeException(MappingException.because(reason));
			actException();
			//assertException();
		}
		
	}

}
