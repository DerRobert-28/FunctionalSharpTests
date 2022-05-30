namespace DerRobert.FunctionalSharpTests.Core {

	using System;


	public class Expectation: ITestClass {

		private ITestClass testClass;
		private readonly World world;

		public Expectation and => this;
		public Expectation the => this;
		
		//
		//	INITIALISATION:
		//

		public static Expectation forWorld(World world) => new Expectation(world);

		public Expectation withLogging(ITestClass testClass) {
			testClass.testMethod($"{testClass}");
			this.testClass = testClass;
			return this;
		}

		//
		//	ASSERTIONS / EXPECTATIONS:
		//

		public Expectation AnyExceptionIsThrown(string? message) {
			testClass.testMethod();
			testClass.assertNotNull(world.lastException, message);
			return this;
		}
		
		public Expectation ArityIsEqualTo(int expected, string? message) {
			testClass.testMethod();
			testClass.assertEquals(expected, world.tuple?.arity(), $"Arity should be {expected}");
			return this;
		}
	
		public Expectation EighthTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._8, $"Eighth tuple value should be {expected}");
			}
			return this;
		}

		public Expectation ExceptionReasonIsEqualTo(string reason, string? message) {
			testClass.testMethod();
			testClass.assertEquals(world.lastException?.Message, reason, message);
			return this;
		}
		
		public Expectation ExceptionTypeIsNotNull(string? message) {
			testClass.testMethod();
			testClass.assertNotNull(world.lastException, message);
			testClass.assertNotEquals(
				world.lastException?.GetType(), typeof(NullReferenceException), message);
			return this;
		}

		public Expectation FifthTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._5, $"Fifth tuple value should be {expected}");
			}
			return this;
		}

		public Expectation FirstTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._1, $"First tuple value should be {expected}");
			}
			return this;
		}

		public Expectation FourthTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._4, $"Fourth tuple value should be {expected}");
			}
			return this;
		}

		public Expectation GenericExceptionTypeEqualTo(Type type, string? message) {
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

		public Expectation MaximumArityEqualTo(int expected, string? message) {
			testClass.testMethod();
			testClass.assertEquals(expected, world.tuple?.MAX_ARITY, $"MAX_ARITY should be {expected}");
			return this;
		}

		public Expectation NinthTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._9, $"Ninth tuple value should be {expected}");
			}
			return this;
		}

		public Expectation SixthTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._6, $"Sixth tuple value should be {expected}");
			}
			return this;
		}	

		public Expectation SecondTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._2, $"Second tuple value should be {expected}");
			}
			return this;
		}

		public Expectation SeventhTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._7, $"Seventh tuple value should be {expected}");
			}
			return this;
		}

		public Expectation ThirdTupleValueIsEqualTo<T>(T expected, string? message) {
			testClass.testMethod();
			if(world?.tuple != null) {
				dynamic actual = world.tuple;
				testClass.assertEquals(expected, actual._3, $"Third tuple value should be {expected}");
			}
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
