namespace DerRobert.FunctionalSharpTests.Core {

	using DerRobert.FunctionalSharp.Interfaces;
	using System;
	using System.Collections.Generic;


	public class World {

		public Exception? exception = null;
		public Exception? lastException = null;

		public string reason = string.Empty;

		public ITuple? tuple = null;

		public Type? type = null;

	}

}
