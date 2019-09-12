using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Calculator
{
	public class Calculator
	{
		public List<string> Separators { get; set; }

		public Calculator()
		{
			Separators = new List<string> { "\n", "," };
		}
		public int Add(string inputString)
		{
			//check if the string is empty
			if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
			{
				return 0;
			}

			inputString = GetCustomDelimiter(inputString);
			List<int> num = GetInputNumbers(inputString);
			ValidateNegativeNumbers(num);
			List<int> numbersLessThanThousand = IgnoreInputGreaterThanThousand(num);

			return (numbersLessThanThousand.Sum());

		}

		private List<int> IgnoreInputGreaterThanThousand(List<int> num)
		{
			return num.Where(x => x <= 1000).ToList();
		}

		private static void ValidateNegativeNumbers(List<int> num)
		{
			var negativeInputs = num.Where(x => x < 0).ToList();

			if (negativeInputs.Count>0)
			{
				throw new ArgumentException($"negatives not allowed {string.Join(",", negativeInputs)}");
			}
		}

		private  List<int> GetInputNumbers(string inputString)
		{
			return inputString.Split(Separators.ToArray(),StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();			
		}

		private  string GetCustomDelimiter(string inputString)
		{
			if (inputString.StartsWith("//"))
			{
				int numberOfDelimiters = CountNumberOfDelimiters(inputString);

				if (numberOfDelimiters > 0)
				{
					inputString = ParseForMultipleDelimiters(inputString, numberOfDelimiters);
				}
				else
				{
					inputString = ParseForSingleDelimiter(inputString);
				}

			}
			
			return inputString;
		}

		private string ParseForSingleDelimiter(string inputString)
		{
			var customDelimiter = inputString[2];
			Separators.Add(customDelimiter.ToString());
			inputString = inputString.Substring(4);
			return inputString;
		}

		private string ParseForMultipleDelimiters(string inputString, int numberOfDelimiters)
		{
			for (int i = 0; i < numberOfDelimiters; i++)
			{
				var startindex = inputString.IndexOf('[');
				var endIndex = inputString.IndexOf(']');
				var delimitter = inputString.Substring(startindex + 1, endIndex - (startindex + 1));
				Separators.Add(delimitter.ToString());
				inputString = inputString.Substring(endIndex + 1);
			}

			return inputString;
		}

		private int CountNumberOfDelimiters(string inputString)
		{
			return inputString.Count(x => x == '[');
		}
	}
	
}
