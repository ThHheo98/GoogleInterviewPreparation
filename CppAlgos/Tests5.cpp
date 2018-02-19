#include "CppUnitTest.h"
#include <string.h>
#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>
 
using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

// https://www.interviewbit.com/problems/matrix-median/
namespace CppAlgos1
{
	TEST_CLASS(InterviewBit5)
	{
	public:
		int findMedian(vector<vector<int> > &A) {
			int l = 0, r = INT_MAX;
			int mid, req = (int)A.size() * (int)A[0].size();
			
			while (r - l > 1) {
				mid = l + (r - l) / 2;
				int cnt = 0;
				for (auto &i : A) {
					//using upper bound in a sorted array to count number of elements smaller than mid
					int p = upper_bound(i.begin(), i.end(), mid) - i.begin();
					cnt += p;
				}
				if (cnt >= (req / 2 + 1)) r = mid;
				else l = mid;
			}
			return r;
		}

		TEST_METHOD(fullJustifyT)
		{
			vector<vector<int> > A(3, vector<int>(3));
			A[0][0] = 1;
			A[0][1] = 3;
			A[0][2] = 5;

			A[1][0] = 2;
			A[1][1] = 6;
			A[1][2] = 9;

			A[2][0] = 3;
			A[2][1] = 6;
			A[2][2] = 9;
			
			int m = findMedian(A);
			
			//assert m == 5
		}
	};
}