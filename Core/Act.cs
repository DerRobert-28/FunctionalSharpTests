namespace DerRobert.FunctionalSharpTests.Core {

	using System;


	public class Act: TestClass {
		
		private TestClass testClass;
		private readonly World world;

		//
		//	INITIALISATION:
		//

		public static Act inWorld(World world) => new Act(world);

		public Act withLogging(TestClass testClass) {
			testClass.testMethod($"{testClass}");
			this.testClass = testClass;
			return this;
		}

		//
		//	ACTIONS:
		//

		public Act throwException() {
			testClass.testMethod();
			try {
				if(world?.exception == null) {
					throw new NullReferenceException("No exception defined.");
				} else {
					testClass.testLog("Exception is caught");
					throw world.exception;
				}
			} catch(Exception e) {
				world.lastException = e;
			}
			return this;
		}

		//
		//	CONSTRUCTOR:
		//
		
		private Act(World world) {
			testClass = this;
			this.world = world;
		}

	}
}
