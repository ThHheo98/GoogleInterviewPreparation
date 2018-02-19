#include "CppUnitTest.h"
#include <string.h>
#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>


#define MAX 256

// Maximum length of an input word
#define MAX_WORD_LEN 500

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;


namespace CppAlgos1
{
	TEST_CLASS(InterviewBit2)
	{
	public:
		vector<string> fullJustify(vector<string> &words, int L) {
			vector<string> res;
			int k = 0, l = 0;
			for (int i = 0; i < words.size(); i += k) {
				for (k = l = 0; i + k < words.size() && l + words[i + k].size() <= L - k; k++) {
					l += words[i + k].size();
				}
				string tmp = words[i];
				for (int j = 0; j < k - 1; j++) {
					if (i + k >= words.size()) tmp += " ";
					else
					{
						int i = (j < (L - l) % (k - 1));
						tmp += string((L - l) / (k - 1) + i, ' ');
					}
					tmp += words[i + j + 1];
				}
				tmp += string(L - tmp.size(), ' ');
				res.push_back(tmp);
			}
			return res;
		}

		TEST_METHOD(fullJustifyT)
		{
			vector<string> w;
			w.push_back("");
			fullJustify(w, 10);
		}
	};
}