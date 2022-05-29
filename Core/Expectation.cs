namespace DerRobert.FunctionalSharpTests.Core {
	
	using System;


	public class Expectation: TestClass {

		private TestClass testClass;
		private readonly World world;

		//
		//	INITIALISATION:
		//

		public static Expectation forWorld(World world) => new Expectation(world);

		public Expectation withLogging(TestClass testClass) {
			testClass.testMethod($"{testClass}");
			this.testClass = testClass;
			return this;
		}

		//
		//	ASSERTIONS / EXPECTATIONS:
		//

		public Expectation anyExceptionIsThrown(string? message = null) {
			testClass.testMethod();
			testClass.assertNotNull(world.lastException, message);
			return this;
		}

		public Expectation exceptionReasonEqualTo(string reason, string? message = null) {
			testClass.testMethod();
			testClass.assertEquals(world.lastException?.Message, reason, message);
			return this;
		}

		public Expectation exceptionTypeIsNotNull(string? message = null) {
			testClass.testMethod();
			testClass.assertNotNull(world.lastException, message);
			testClass.assertNotEquals(
				world.lastException?.GetType(), typeof(NullReferenceException), message);
			return this;
		}

		//
		//	CONSTRUCTOR:
		//

		private Expectation(World world) {
			testClass = this;
			this.world = world;
		}

	}

}
