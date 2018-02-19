using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/substring-concatenation/
    ///     http://qa.geeksforgeeks.org/3916/find-starting-indices-substring-that-concatenation-each-word
    ///     http://www.programcreek.com/2014/06/leetcode-substring-with-concatenation-of-all-words-java/
    ///     https://leetcode.com/problems/substring-with-concatenation-of-all-words/
    ///     аналог задачи
    ///     http://www.programcreek.com/2013/02/longest-substring-which-contains-2-unique-characters/
    /// </summary>
    /*
     You are given a string, S, and a list of words, L, that are all of the same length.

Find all starting indices of substring(s) in S that is a concatenation of each word in L exactly once and without any intervening characters.

Example :

S: "barfoothefoobarman"
L: ["foo", "bar"]
You should return the indices: [0,9].
(order does not matter).
Think of the bruteforce solution. 
Lets say the size of every word is wsize and number of words is lsize. 
You start at every index i. Look at every lsize number of chunks of size wsize and note down the words. Then match the set of words encountered to the set of words expected.

Now, lets look at ways we can optimize this. 
Right now, to match words, we do it letter by letter. How about hashing the words ? 
With hashing, hash(w1) + hash(w2) = hash(w2) + hash(w1). 
In short, when adding the hashes, the order of words does not matter. 
Can we optimize the matching of all the words encountered using that ? Can we use sliding pointers to move to index i + wsize from i ?
         */

    //с++ solution
    /*
     unsigned int myhash(const string &s) {
unsigned int ret = 0;
for (int i = 0; i < s.length(); i++) {
    ret = (ret * 100 + s[i]) % 9999997;
}
return ret;
}

bool checkSubstring(const string &S, int j, unordered_multiset<string> L) {
int lsize = L.size(), wsize = L.begin()->size();
for (int i = 0; i < lsize; i++) {
    if (L.find(S.substr(j + i * wsize, wsize)) == L.end()) return false;
    L.erase(L.find(S.substr(j + i * wsize, wsize)));
}
return true;
}

vector<int> Solution::findSubstring(string S, const vector<string> &L) {
vector<int> ret;
if (L.empty()) return ret;
unsigned int hashsum = 0;
for (int i = 0; i < L.size(); i++) 
    hashsum += myhash(L[i]);

int wsize = L[0].size(), lsize = L.size();
for (int i = 0; i < wsize; i++) {
    // In this loop, we will consider all starting positions in S where start % wsize = i.
    vector<unsigned int> hashes;
    int hashsum2 = 0;
    // Calculate the hash of wordsize for all start positions we are considering ( start % wsize = i ) 
    for (int j = i; j < S.size(); j += wsize) {
        hashes.push_back(myhash(S.substr(j, wsize)));
    }
    if (hashes.size() < lsize) continue;
    // Calculare the hashsum of string size lsize * wsize from index i. 
    for (int j = 0; j < lsize; j++) hashsum2 += hashes[j];
    // If hashes are same, very high probability that this is part of our solution. 
    if (hashsum == hashsum2) ret.push_back(i);

    for (int j = lsize; j < hashes.size(); j++) {
        // pop out [i, i + wsize] prefix  and include [j, j+wsize] suffix in our string. 
        // In other words, adding new wsize chars. 
        hashsum2  = hashsum2 - hashes[j - lsize] + hashes[j];
        if (hashsum == hashsum2) ret.push_back(i + (j - lsize + 1) * wsize);
    }
}

// check the final result
unordered_multiset<string> Lset(L.begin(), L.end());
vector<int> ret2;
for (int i = 0; i < ret.size(); i++) {
    if (checkSubstring(S, ret[i], Lset)) 
        ret2.push_back(ret[i]);
}

return ret2;
}
     */
    public class SubstringConcatenation
    {
        [Test]
        public void Test()
        {
            var res = findSubstring("barfoothefoobarman", new List<string> { "foo", "bar" });
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(9, res[1]);

            res = findSubstring1("barfoothefoobarman", new List<string> { "foo", "bar" });
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(9, res[1]);
        }

        public List<int> findSubstring(string s, List<string> words)
        {
            var result = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Count == 0)
                return result;

            //frequency of words
            var dictionary = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (!dictionary.ContainsKey(w))
                    dictionary.Add(w, 0);
                dictionary[w]++;
            }

            var len = words[0].Length;

            for (var j = 0; j < len; j++)
            {
                var currentDictionary = new Dictionary<string, int>();
                var start = j; //start index of start
                var count = 0; //count total qualified words so far

                for (var i = j; i <= s.Length - len; i = i + len)
                {
                    var sub = s.Substring(i, len);
                    if (dictionary.ContainsKey(sub))
                    {
                        //set frequency in current map
                        if (!currentDictionary.ContainsKey(sub))
                            currentDictionary.Add(sub, 0);
                        currentDictionary[sub]++;

                        count++;

                        while (currentDictionary[sub] > dictionary[sub])
                        {
                            var left = s.Substring(start, len);
                            currentDictionary[left]--;

                            count--;
                            start = start + len;
                        }

                        if (count == words.Count)
                        {
                            result.Add(start); //add to result

                            //shift right and reset currentMap, count & start point         
                            var left = s.Substring(start, len);
                            currentDictionary[left]--;
                            count--;
                            start = start + len;
                        }
                    }
                    else
                    {
                        currentDictionary.Clear();
                        start = i + len;
                        count = 0;
                    }
                }
            }

            return result;
        }

        public List<int> findSubstring1(string s, List<string> words)
        {
            var res = new List<int>();

            if (string.IsNullOrEmpty(s) || words == null || words.Count == 0)
                return res;

            var occurences = new Dictionary<string, int>();

            foreach (var str in words)
                occurences[str] = occurences.ContainsKey(str) ? occurences[str] + 1 : 1;

            var size = words.Count;
            int len = words[0].Length;

            for (var i = 0; i <= s.Length - len * size; i++)
            {
                var index = i;
                var loop = size;
                var copy = new Dictionary<string, int>(occurences);

                for (var j = 0; j < loop; j++)
                {
                    var str = s.Substring(index + j * len, len);
                    if (!copy.ContainsKey(str))
                        break;

                    var val = copy[str];
                    if (val == 1)
                        copy.Remove(str);
                    else
                        copy[str]--;
                }

                if (copy.Count == 0)
                    res.Add(i);
            }

            return res;
        }
    }
}
