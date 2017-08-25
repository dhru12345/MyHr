
/******************************************************************************************
Merging Communities
//http://www.mathblog.dk/disjoint-set-data-structure/
//https://stackoverflow.com/questions/31452639/merging-communities-using-sets-data-structure
*******************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static int[] parent, rank, m;
    // Finds the representative of the set that i is an element of
    static int find(int i) {
        // If i is the parent of itself
        if (i == parent[i]) {
            // Then i is the representative of his set
            return i;
        }
        // Else if i is not the parent of itself
        // Then i is not the representative of his set,
        // so we recursively call Find on its parent
        int res = find(parent[i]);
        // We then cache the result by moving i's node directly under the representative of his set
        parent[i] = res;
        return res;

    }

    static void union(int i, int j) {

        // Find the representatives (or the root nodes) for the set that includes i
        int irep = find(i);
        // And do the same for the set that includes j
        int jrep = find(j);
        // Elements are in the same set, no need to unite anything.
        if (irep == jrep)
            return;
        if (rank[irep] > rank[jrep]) {
            parent[jrep] = irep;
            m[irep] += m[jrep];
        } else if (rank[irep] < rank[jrep]) {
            parent[irep] = jrep;
            m[jrep] += m[irep];
        } else {
            parent[jrep] = irep;
            rank[irep]++;
            m[irep] += m[jrep];
        }
    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string str = Console.ReadLine();
        // Console.WriteLine(str);

        int[] NQ = Array.ConvertAll(str.Split(new char[] { ' ' }), int.Parse);

        int N = NQ[0];
        int Q = NQ[1];
        parent = new int[N + 1];
        rank = new int[N + 1];
        m = new int[N + 1];
        for (int i = 0; i <= N; i++) {
            parent[i] = i;
            rank[i] = 1;
            m[i] = 1;
        }


        for (int i = 0; i < Q; i++) {

            string[] MQValues = Console.ReadLine().Split(new char[] { ' ' });
            string MorQ = MQValues[0];
            int id1 = Convert.ToInt32(MQValues[1]);
            int id2 = MQValues.Length > 2 ? Convert.ToInt32(MQValues[2]) : -1;

            if (MorQ == "M") {
                union(id1, id2);
            } else if (MorQ == "Q") {
                Console.WriteLine(m[find(id1)]);
            }
        }


    }
}
/******************************************************************************************
Components in a graph
//http://www.mathblog.dk/disjoint-set-data-structure/
//https://stackoverflow.com/questions/31452639/merging-communities-using-sets-data-structure
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    class DisjointSet {
        int[] parent;
        int[] size;

        public DisjointSet(int n) {
            parent = new int[n + 1];
            size = new int[n + 1];
            for (int i = 0; i < n; i++) {
                parent[i] = i;
                size[i] = 1;
            }
        }
        public bool connected(int p, int q) {
            return find(p) == find(q);
        }
        private int find(int p) {
            // If i is the parent of itself
            if (p == parent[p]) {
                // Then p is the representative of his set
                return p;
            }
            // Else if p is not the parent of itself
            // Then p is not the representative of his set,
            // so we recursively call Find on its parent
            int res = find(parent[p]);
            // We then cache the result by moving i's node directly under the representative of his set
            parent[p] = res;
            return res;

        }
        public void union(int p, int q) {
            int rootP = find(p);
            int rootQ = find(q);
            if (rootP == rootQ) return;

            if (size[rootP] < size[rootQ]) {
                parent[rootP] = rootQ;
                size[rootQ] += size[rootP];
                size[rootP] = 0;
            } else {
                parent[rootQ] = rootP;
                size[rootP] += size[rootQ];
                size[rootQ] = 0;
            }
        }

        public int[] getMinMaxSize() {
            int min = Int32.MaxValue;
            int max = 0;
            for (int i = 1; i < size.Length; i++) {
                if (size[i] > 1) { //we cannot count the nodes that aren't connected to any other node
                    if (min > size[i])
                        min = size[i];
                    if (max < size[i])
                        max = size[i];
                }
            }
            int[] result = { min, max };
            return result;
        }

    }
    static void Main(String[] args) {

        int N = Convert.ToInt32(Console.ReadLine());
        DisjointSet dSet = new DisjointSet(N + N);
        for (int i = 0; i < N; i++) {
            int[] GB = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }), int.Parse);
            dSet.union(GB[0], GB[1]);
        }
        int[] result = dSet.getMinMaxSize();
        Console.WriteLine(result[0] + " " + result[1]);

    }
}
/******************************************************************************************
Kundu and Tree
//http://www.mathblog.dk/disjoint-set-data-structure/
//https://stackoverflow.com/questions/31452639/merging-communities-using-sets-data-structure
*******************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    //http://gauamgraph.blogspot.com/2015/09/kundu-and-tree.html
    class DisjointSet {
        int[] parent;
        int[] size;
        const int PSIZE = 100010;

        public DisjointSet(int n) {
            parent = new int[PSIZE];
            size = new int[PSIZE];
            for (int i = 0; i <= n + 1; i++) {
                parent[i] = i;
                size[i] = 1;
            }
        }
        public bool connected(int p, int q) {
            return find(p) == find(q);
        }
        public int sizeValue(int i) {
            int ret = 0;
            if (i >= 0 && i < size.Length) {
                ret = size[i];
            }
            return ret;
        }
        public int find(int p) {
            // If i is the parent of itself
            if (p == parent[p]) {
                // Then p is the representative of his set
                return p;
            }
            // Else if p is not the parent of itself
            // Then p is not the representative of his set,
            // so we recursively call Find on its parent
            int res = find(parent[p]);
            // We then cache the result by moving i's node directly under the representative of his set
            parent[p] = res;
            return res;

        }
        public void union(int p, int q) {
            int rootP = find(p);
            int rootQ = find(q);
            if (rootP == rootQ) return;

            if (size[rootP] > size[rootQ]) {
                parent[rootQ] = rootP;
                size[rootP] += size[rootQ];
                size[rootQ] = 0;
            } else {

                parent[rootP] = rootQ;
                size[rootQ] += size[rootP];
                size[rootP] = 0;
            }
        }


    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        const int MOD = 1000000007;
        long[] B = new long[100009];
        long[] C = new long[100009];
        long[] D = new long[100009];


        int N = Convert.ToInt32(Console.ReadLine());
        DisjointSet dSet = new DisjointSet(N);
        for (int i = 0; i < N - 1; i++) {
            string[] strs = Console.ReadLine().Split(new char[] { ' ' });
            int a = Convert.ToInt32(strs[0]);
            int b = Convert.ToInt32(strs[1]);
            string color = strs[2];
            if (color == "r")
                continue;
            else {
                dSet.union(a, b);
            }
        }
        List<int> count1 = new List<int>();
        for (int i = 0; i <= N; i++)
            count1.Add(0);
        for (int i = 1; i <= N; i++) {
            var sz = dSet.sizeValue(i);
            // if (sz!=0)               
            count1[i] = dSet.sizeValue(i); //Get the size of all sets
        }
        B[N - 1] = count1[N];
        int ic;
        for (ic = N - 2; ic >= 0; ic--) {
            B[ic] = (B[ic + 1] + count1[ic + 1]) % MOD;
        }
        for (ic = 1; ic < N - 1; ic++)
            C[ic] = (count1[ic + 1] * B[ic + 1]) % MOD;

        D[N - 2] = C[N - 2];
        for (ic = N - 3; ic >= 1; ic--)
            D[ic] = (D[ic + 1] + C[ic]) % MOD;
        long sum = 0;
        for (ic = 0; ic < N - 2; ic++)
            sum = (sum + count1[ic + 1] * D[ic + 1]) % MOD;
        Console.WriteLine((MOD + sum) % MOD);
    }
}