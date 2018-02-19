#include "CppUnitTest.h"
#include <string.h>
#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

//https://www.interviewbit.com/problems/smallest-multiple-with-0-and-1/
namespace CppAlgos1
{
	TEST_CLASS(InterviewBit1)
	{
	public:
		string solve(vector<int> visited, vector<int> val, vector<int> parent, int n)
		{
			string ans = "";
			queue<int> queue;

			//initial node
			int temp = 1 % n;
			visited[temp] = 1;
			val[temp] = 1;
			queue.push(temp);
			
			int p, q, i, tot = 0;
			while (true)
			{				
				temp = queue.front();
				queue.pop();
				
				p = temp;

				if (p == 0)
				{
					do
					{
						ans += (char)(val[p] + '0');
						p = parent[p];
					} while (p != 0);

					std::reverse(ans.begin(), ans.end());
					return ans;
				}
				else
				{
					//visit two neighbors p*10 and 	
					q = (p * 10) % n; // p * 10
					if (visited[q] == 0) // if already not visited
					{
						queue.push(q);
						visited[q] = 1;
						parent[q] = p;
						val[q] = 0;
					}

					q = ((p * 10) % n) + 1; // p*10+1

					if (q >= n) q -= n;

					if (visited[q] == 0)
					{
						queue.push(q);
						visited[q] = 1;
						parent[q] = p;
						val[q] = 1;
					}
				}				
			}
		}

		TEST_METHOD(Mult1and0)
		{
			int a = 2;
						
			vector<int> visited(a);
			vector<int> parent(a);
			vector<int> val(a);

			string s = solve(visited, val, parent, a);
			Logger::WriteMessage(s.c_str());			
		}
	};
}