namespace DerRobert.FunctionalSharpTests.Core {

	public class Expect {
		
		public readonly Expectation That;

		//
		//	INITIALISATION:
		//

		public static Expect forWorld(World world) => new Expect(world);

		public Expect withLogging(TestClass testClass) {
			That.withLogging(testClass);
			return this;
		}

		//
		//	CONSTRUCTOR:
		//

		private Expect(World world) {
			That = Expectation.forWorld(world);
		}

	}

}
