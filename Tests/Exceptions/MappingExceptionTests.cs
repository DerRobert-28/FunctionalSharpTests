namespace DerRobert.FunctionalSharpTests.Tests.Exceptions {

	using DerRobert.FunctionalSharp.Exceptions;
	using Microsoft.VisualStudio.TestTools.UnitTesting;


	[TestClass]
	public class MappingExceptionTests: Exceptions {

		[TestMethod("Test of throwing a 'MappingException'")]
		public void testMappingException() {
			testMethod("Test of throwing a 'MappingException'");
			arrangeException(new MappingException("throwing MappingException"));
			actException();
			assertException();
		}
		
	}

}
