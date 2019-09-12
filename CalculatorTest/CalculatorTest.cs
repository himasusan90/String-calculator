using NUnit.Framework;
using String_Calculator;
using System;

namespace Tests
{
	public class Tests
	{
		Calculator calculator;
		[SetUp]
		public void Setup()
		{
			 calculator = new Calculator();
		}

		[Test]
		public void Add_EmptyString_ReturnsZero()
		{
			int sum=calculator.Add("");
			Assert.AreEqual(sum, 0);
		}

		[Test]
		public void Add_SingleNumber_ReturnsNumber()
		{
			int sum = calculator.Add("5");
			Assert.AreEqual(sum, 5);
		}

		[TestCase(7,"5,2")]
		public void Add_TwoNumber_Returns_Sum(int expected,string value)
		{
			int sum = calculator.Add(value);
			Assert.AreEqual(expected,sum);
		}

		[TestCase(29, "5,2,5,8,9")]
		public void Add_Unknown_Numbers_Returns_Sum(int expected, string value)
		{
			int sum = calculator.Add(value);
			Assert.AreEqual(expected,sum);
		}

		[Test]
		public void TrimEmpty_Spaces_Return_Sum()
		{
			int sum = calculator.Add("5,2,5,,9,,,,");
			Assert.AreEqual(sum, 21);
		}

		[Test]
		public void Add_Number_Separated_By_NewLine()
		{
			int sum = calculator.Add("5\n2,5,,9,,,,");
			Assert.AreEqual(sum, 21);
		}

		[Test]
		public void Add_Number_Separated_By_Custom_Input_Delimiter()
		{
			var sum = calculator.Add("//;\n\n5;6;2;;;");
			Assert.AreEqual(sum, 13);
		}
		[Test]
		public void Adding_Negative_Number_Must_Throw_Exception()
		{
			TestDelegate addNegativeNums=() => calculator.Add("//;\n-5;6;-2;;;");
			Assert.Throws<ArgumentException>(addNegativeNums);

		}
		[Test]
		public void Add_Number_GreaterthanThousand_Ignored()
		{
			var sum = calculator.Add("1001,2");
			Assert.AreEqual(sum, 2);
		}

		[Test]
		public void Add_Number_With_Delimiter_AnyLength()
		{
			var sum = calculator.Add("//[*****]\n1*****2*****3");
			Assert.AreEqual(sum, 6);
		}
		[Test]
		public void Add_Number_With_MultiDelimiter_AnyLength()
		{
			var sum = calculator.Add("//[*][%]\n1*2%3");
			Assert.AreEqual(sum, 6);
		}
	}
}