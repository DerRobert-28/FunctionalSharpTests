namespace DerRobert.FunctionalSharpTests.Core {
	using DerRobert.FunctionalSharp.Interfaces;
	using System;


	public class Arrange: ITestClass {
		
		private ITestClass testClass;
		private readonly World world;

		//
		//	INITIALISATION:
		//

		public static Arrange theWorld(World world) => new Arrange(world);

		public Arrange withLogging(ITestClass testClass) {
			testClass.testMethod($"{testClass}");
			this.testClass = testClass;
			return this;
		}

		//
		//	ARRANGEMENT:
		//

		public Arrange withException(Exception exception) {
			testClass.testMethod($"{exception}");
			world.exception = exception;
			return this;
		}

		public Arrange withReason(string reason) {
			testClass.testMethod($"\"{reason}\"");
			world.reason = reason;
			return this;
		}

		public Arrange withTuple(ITuple tuple) {
			testClass.testMethod($"{tuple}");
			world.tuple = tuple;
			return this;
		}

		public Arrange withType(Type type) {
			testClass.testMethod($"{type}");
			world.type = type;
			return this;
		}

		//
		//	CONSTRUCTOR:
		//

		private Arrange(World world) {
			testClass = this;
			this.world = world;
		}

	}

}
