#include "CppUnitTest.h"
#include <string.h>
#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>
#include <unordered_map>
 
using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

// https://www.interviewbit.com/problems/matrix-median/
namespace CppAlgos1
{
	TEST_CLASS(InterviewBit6)
	{
	public:
		int test()
		{
			int B = 2;
			//vector<int> A = { 4, 7, -4, 2, 2, 2, 3, -5, -3, 9, -4, 9, -7, 7, -1, 9, 9, 4, 1, -4, -2, 3, -3, -5, 4, -7, 7, 9, -4, 4, -8 };
			vector<int> A = { 1,1,1 };

			unordered_map<int, vector<int>> mymap;
			vector<int> v;
			int index1 = 0, index2 = INT_MAX;
			int i, j;
			for (i = 0; i < A.size(); i++)
			{
				mymap[A[i]].push_back(i);

			}

			for (auto it = mymap.begin(); it != mymap.end(); ++it)
				std::cout << " " << it->first;
			std::cout << std::endl;

			int k;
			for (i = 0; i<A.size(); i++) {
				k = B - A[i];
				if (mymap.find(k) != mymap.end()) {
					index1 = i;
					index2 = i;
					j = 0;
					while (j<mymap[k].size()) {
						if (mymap[k][j] != i) {
							index2 = mymap[k][j];
							j = mymap[k].size();
						}
						j++;
					}

					if (index1<index2) {
						if (v.empty()) {
							cout << "empty " << index1 << " " << index2 << endl;
							v.push_back(index1);
							v.push_back(index2);

						}
						else {
							if (v[v.size() - 1]>index2) {
								v.pop_back(); v.pop_back();
								v.push_back(index1);
								v.push_back(index2);
								cout << "not empty " << index1 << " " << index2 << endl;
							}
						}
					}

				}
			}
			if (!v.empty()) {
				v[0]++;
				v[1]++;
			}

			cout << v[0] << endl;
			cout << v[1] << endl;
		}
	};
}