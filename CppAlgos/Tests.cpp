
#include "CppUnitTest.h"
#include <string.h>
#include <iostream>
#include <vector>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace CppAlgos
{		
	TEST_CLASS(CrackingTheCodingInterview)
	{
	public:
		
		TEST_METHOD(Test12) //Implement a function void reverse(char* str) in C or C++ which reverses a null terminated string.			
		{
			char* str = "ABC";
			printf("%d", strlen(str) - 1);
			/*for (int i = 0, j = strlen(str) - 1; i < j; i++, j--)
			{
				char c = str[i];
				str[i] = str[j];
				str[j] = c;
			}*/
			//Assert::AreEqual("CBA", str);
		}
		
		TEST_METHOD(GreyCode) //Implement a function void reverse(char* str) in C or C++ which reverses a null terminated string.			
		{
			int n = 3;
			//
			// base case
			if (n <= 0)
				return;

			// 'arr' will store all generated codes
			std::vector<std::string> arr;

			// start with one-bit pattern
			arr.push_back("0");
			arr.push_back("1");

			// Every iteration of this loop generates 2*i codes from previously
			// generated i codes.
			int i, j;
			for (i = 2; i < (1 << n); i = i << 1)
			{
				// Enter the previously generated codes again in arr[] in reverse
				// order. Nor arr[] has double number of codes.
				for (j = i - 1; j >= 0; j--)
					arr.push_back(arr[j]);

				// append 0 to the first half
				for (j = 0; j < i; j++)
					arr[j] = "0" + arr[j];

				// append 1 to the second half
				for (j = i; j < 2 * i; j++)
					arr[j] = "1" + arr[j];
			}

			// print contents of arr[]
			for (i = 0; i < arr.size(); i++)
				std::cout << arr[i] << std::endl;
		}
	};
}