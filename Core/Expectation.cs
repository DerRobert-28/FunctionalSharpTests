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

		public Expectation genericExceptionTypeEqualTo(Type type, string? message = null) {
			testClass.testMethod();
			//
			Type? baseType = type.BaseType;
			testClass.assertNotNull(baseType, "Exception type should be inherited.");
			//
			Exception? lastException = world.lastException;
			testClass.assertNotNull(lastException, "No exception has been thrown.");
			//
			Type? lastExceptionType = lastException?.GetType();
			testClass.assertEquals(baseType, lastExceptionType, $"Base type should be {baseType?.Name}.");
			//
			Type? exceptionType = lastException?.GetType();
			Type[]? genericTypes = exceptionType?.GenericTypeArguments;
			testClass.assertNotNull(genericTypes, "Exception type should be generic.");
			testClass.assertEquals(genericTypes?.Length, 1, "Exception type should be generic.");
			//
			Type? theType = genericTypes?[0];
			testClass.assertEquals(theType, type, message);
			//
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
