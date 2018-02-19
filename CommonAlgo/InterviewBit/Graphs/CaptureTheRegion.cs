namespace CommonAlgo.InterviewBit.Graphs
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/capture-regions-on-board/
    ///     http://www.geeksforgeeks.org/given-matrix-o-x-replace-o-x-surrounded-x/
    /// </summary>
    public class CaptureTheRegion
    {
        /*
         
         void fill(vector<vector<char> > &a, int i, int j, char oldChar, char newChar)
{
    // base cases
    if (i<0 || i>=a.size() || j<0||j>=a[0].size()) return;
    
    if (a[i][j]!=oldChar) return;
    
    a[i][j] = newChar;
    
    fill(a, i + 1, j, oldChar, newChar);
    fill(a, i, j + 1, oldChar, newChar);
    fill(a, i - 1, j, oldChar, newChar);
    fill(a, i, j - 1, oldChar, newChar);
}

void Solution::solve(vector<vector<char> > &a) {
   int n = a.size();
   int m = a[0].size();
   for (int i = 0; i < n; ++i)
   {
       for(int j = 0; j < m; ++j)
       {
           if (a[i][j] == 'O') a[i][j] = '-';
       }
   }
   
   // replace '-' by 'O' on the edge
   //left
   for(int i = 0; i<n; ++i)
   {
       if (a[i][0] == '-') fill(a, i, 0, '-', 'O');
   }
   //right
   for(int i = 0; i<n; ++i)
   {
       if (a[i][m-1] =='-') fill(a, i, m-1, '-', 'O');
   }
   //top
   for(int i = 0; i<m; ++i)
   {
       if (a[0][i] == '-') fill(a, 0, i, '-', 'O');
   }
   //bottom
   for(int i = 0; i<m; ++i)
   {
       if (a[n-1][i] == '-') fill(a, n-1, i, '-', 'O');
   }
   
   // replace remain cells with '-' by 'x'
   for(int i = 0; i < n; ++i)
   {
       for(int j = 0; j < m; ++j)
       {
           if (a[i][j] == '-') a[i][j] = 'X';
       }
   }
}

         
         */
    }
}
