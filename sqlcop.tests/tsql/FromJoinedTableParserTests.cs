using System;
using NUnit.Framework;
using sqlcop.tsql;

namespace sqlcop.tests
{
	[TestFixture]
	[Category("TSQL Parser")]
	public class FromJoinedTableParserTests
	{
		[Test]
		public void Recognizes_Simplest_Join()
		{
			_input = "SELECT * FROM l JOIN r ON l.moo = r.moo";
			EnsureParserRecognizesInput();
		}
			
		[Test]
		public void Recognizes_Simplest_Join_With_Parentheses()
		{
			_input = "SELECT * FROM l JOIN r ON (l.moo = r.moo)";
			EnsureParserRecognizesInput();
		}
			
		[SetUp]
		public void RunBeforeEachTest()
		{
			_scanner = new Scanner();
			_parser = new Parser(_scanner);
		}
		
		private void EnsureParserRecognizesInput()
		{
			_scanner.SetSource(_input, 0);
			Assert.That(_parser.Parse(), "Failed on: " + _input);
		}
		
		private string _input;
		private Scanner _scanner;
		private Parser _parser;
	}
}

