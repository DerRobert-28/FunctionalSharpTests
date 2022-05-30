namespace DerRobert.FunctionalSharpTests.Core {

	using DerRobert.FunctionalSharp.Interfaces;
	using System;


	public class World {

		public Exception? exception = null;
		public Exception? lastException = null;

		public string reason = string.Empty;

		public ITuple? tuple = null;

		public Type? type = null;

	}

}
