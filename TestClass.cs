namespace DerRobert.FunctionalSharp.Tests {

	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Text;

	using static System.IO.Directory;
	

	abstract public class TestClass {

		private static bool openLogFile = true;
		private static bool openLogPath = false;
		private static int testStep = 0;

		private FileStream? logFile;
		private string? testPath;

		[TestInitialize]
		public void before() {
			string fileName = $"log-{getTimeStamp()}.txt";
			testPath = getPath();
			CreateDirectory(testPath);
			logFile = File.Open($"{testPath}\\{fileName}", FileMode.Append, FileAccess.Write);
		}

		[TestCleanup]
		public void after() {
			if(logFile != null) {
				logFile.Close();
				logFile.Dispose();
				if(openLogFile) {
					Process.Start("notepad.exe" , logFile.Name);
					openLogFile = false;
				}
			}
			if(openLogPath && testPath != null) {
				Process.Start("explorer.exe" , testPath);
				openLogPath = false;
			}
		}


		protected void assertEquals<T>(T expected, T actual, string? message) {
			try {
				Assert.AreEqual(expected, actual, message);
			} catch(Exception e) {
				testLog($"{e.GetType()}: {e.Message}\nStackTrace:\n{e.StackTrace}");
				throw;
			}
		}

		private string getPath() {
			return $"{GetCurrentDirectory()}\\[TESTS]";
		}

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

		protected void testMethod(string? info = null) {
			string? caller = new StackTrace()?.GetFrame(1)?.GetMethod()?.Name;
			if(info == null) {
				testLog($"[{caller}]");
			} else {
				testLog($"[{caller}] {info}");
			}
		}

		protected void testLog(string? log = null) {
			if(log != null) {
				UTF8Encoding unicode = new UTF8Encoding(true);
				byte[] info = unicode.GetBytes($"{DateTime.Now},{getTestStep()}: {log}\n");
				logFile?.Write(info, 0, info.Length);
			}
		}

	}

}
