namespace DerRobert.FunctionalSharpTests.Core {

	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Text;
	using System.Threading;
	using static System.IO.Directory;
	

	public abstract class TestClass {

		private static bool openLastLogFileAfterTesting = false;
		private static bool openContainingFolderAfterTesting = true;
		private static int testStep = 0;
		
		private FileStream? logFile;
		private static string? testPath;
		

		[TestInitialize]
		public void before() {
			Thread.Sleep(1);	//	patch for logfile
			string fileName = $"log-{getTimeStamp()}.txt";
			testPath = getPath();
			try {
				CreateDirectory(testPath);
			} catch {}
			try {
				if(logFile == null) {
					logFile = File.Open($"{testPath}\\{fileName}", FileMode.Append, FileAccess.Write);
				}
			} catch {}
		}


		[TestCleanup]
		public void after() {
			if(logFile != null) {
				logFile.Close();
				logFile.Dispose();
				if(openLastLogFileAfterTesting) {
					Process.Start("notepad.exe" , logFile.Name);
					openLastLogFileAfterTesting = false;
				}
			}
			if(openContainingFolderAfterTesting && testPath != null) {
				Process.Start("explorer.exe" , testPath);
				openContainingFolderAfterTesting = false;
			}
		}
		
		//
		//	ASSERTIONS:
		//
		
		public void assertEquals<T, U>(T expected, U actual, string? message) {
			try {
				Assert.AreEqual(expected, actual, message);
			} catch(Exception e) {
				testLog($"{e.GetType()}: {e.Message}\nStackTrace:\n{e.StackTrace}");
				throw;
			}
		}

		public void assertIsNull<T>(T expected, string? message) {
			try {
				Assert.IsNull(expected, message);
			} catch(Exception e) {
				testLog($"{e.GetType()}: {e.Message}\nStackTrace:\n{e.StackTrace}");
				throw;
			}
		}

		public void assertNotEquals<T, U>(T expected, U actual, string? message) {
			try {
				Assert.AreNotEqual(expected, actual, message);
			} catch(Exception e) {
				testLog($"{e.GetType()}: {e.Message}\nStackTrace:\n{e.StackTrace}");
				throw;
			}
		}

		public void assertNotNull<T>(T expected, string? message) {
			try {
				Assert.IsNotNull(expected, message);
			} catch(Exception e) {
				testLog($"{e.GetType()}: {e.Message}\nStackTrace:\n{e.StackTrace}");
				throw;
			}
		}

		//
		//	LOGGING:
		//

		public void testLog(string? log = null) {
			if(log != null) {
				UTF8Encoding unicode = new UTF8Encoding(true);
				byte[] info = unicode.GetBytes($"{DateTime.Now},{getTestStep()}: {log}\n");
				logFile?.Write(info, 0, info.Length);
			}
		}

		public void testMethod(string? info = null) {
			string? caller = new StackTrace()?.GetFrame(1)?.GetMethod()?.Name;
			if(info == null) {
				testLog($"[{caller}]");
			} else {
				testLog($"[{caller}] {info}");
			}
		}
		
		//
		//	PRIVATE METHODS:
		//

		private string getPath() => $"{GetCurrentDirectory()}\\..\\TestResults";

		private string getTestStep() {
			testStep += 10001;
			string stepString = $"{testStep}".Substring(1);
			testStep -= 10000;
			return stepString;
		}

		private long getTimeStamp() {
			long ticks = DateTime.Now.ToUniversalTime().Ticks;
			long universalTime = 621355968000000000;
			long milliSeconds = 10000000;
			return (ticks - universalTime) / milliSeconds;
		}

	}

}
