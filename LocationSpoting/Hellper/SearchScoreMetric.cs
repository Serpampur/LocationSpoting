namespace LocationSpoting.Hellper
{
    public class SearchScoreMetric : ISearchScoreMetric
    {
      
        public  int CalculateScore(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s, "String Cannot Be Null Or Empty");
            }

            if (string.IsNullOrEmpty(t))
            {
                throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
            }

            int n = s.Length; 
            int m = t.Length;
            
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }
            int[] p = new int[n + 1];
            int[] d = new int[n + 1];         
            int i; 
            int j; 

            for (i = 0; i <= n; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= m; j++)
            {
                char tJ = t[j - 1]; 
                d[0] = j;
                for (i = 1; i <= n; i++)
                {
                    int cost = s[i - 1] == tJ ? 0 : 1;                                                                
                    d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                }     
                int[] dPlaceholder = p; 
                p = d;
                d = dPlaceholder;
            }
            return p[n];
        }
    }
}
