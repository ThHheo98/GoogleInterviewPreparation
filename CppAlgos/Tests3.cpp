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

//https://www.interviewbit.com/problems/shortest-unique-prefix/
namespace CppAlgos1
{
	TEST_CLASS(InterviewBit2)
	{
	public:
		// C++ program to print all prefixes that
		// uniquely reprsent words.

		// Trie Node.
		struct trieNode
		{
			struct trieNode *child[MAX];
			int freq;  // To store frequency
		};

		// Function to create a new trie node.
		struct trieNode *newTrieNode(void)
		{
			struct trieNode *newNode = new trieNode;
			newNode->freq = 1;
			for (int i = 0; i < MAX; i++)
				newNode->child[i] = NULL;
			return newNode;
		}

		// Method to insert a new string into Trie
		void insert(struct trieNode *root, string str)
		{ 
			struct trieNode *pCrawl = root;

			// Traversing over the length of given str.
			for (int level = 0; level < str.length(); level++)
			{
				// Get index of child node from current character
				// in str.
				int index = str[level];

				// Create a new child if not exist already
				if (!pCrawl->child[index])
					pCrawl->child[index] = newTrieNode();
				else
					(pCrawl->child[index]->freq)++;

				// Move to the child
				pCrawl = pCrawl->child[index];
			}
		}

		// This function prints unique prefix for every word stored
		// in Trie. Prefixes one by one are stored in prefix[].
		// 'ind' is current index of prefix[]
		void findPrefixesUtil(struct trieNode *root, char prefix[],
			int ind)
		{
			// Corner case
			if (root == NULL)
				return;

			// Base case
			if (root->freq == 1)
			{
				prefix[ind] = '\0';
				string s(prefix);
				Logger::WriteMessage(s.c_str());
				Logger::WriteMessage("\n");
				return;
			}

			for (int i = 0; i < MAX; i++)
			{
				if (root->child[i] != NULL)
				{
					prefix[ind] = i;
					findPrefixesUtil(root->child[i], prefix, ind + 1);
				}
			}
		}

		// Function to print all prefixes that uniquely
		// represent all words in arr[0..n-1]
		void findPrefixes(string arr[], int n)
		{
			// Construct a Trie of all words
			struct trieNode *root = newTrieNode();
			root->freq = 0;
			for (int i = 0; i < n; i++)
				insert(root, arr[i]);

			// Create an array to store all prefixes
			char prefix[MAX_WORD_LEN];

			// Print all prefixes using Trie Traversal
			findPrefixesUtil(root, prefix, 0);
		}

		TEST_METHOD(Trie)
		{
			string arr[] = { "zebra", "dog", "duck", "dove" };
			int n = sizeof(arr) / sizeof(arr[0]);
			findPrefixes(arr, n);
		}
	};
}