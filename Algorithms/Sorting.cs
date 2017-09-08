/***********************************************************
 * Big Sorting
 * *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] unsorted = new string[n];
        for (int unsorted_i = 0; unsorted_i < n; unsorted_i++) {
            unsorted[unsorted_i] = Console.ReadLine();
        }

        Array.Sort(unsorted, (string a, string b) => {
            if (a.Length == b.Length)
                return string.CompareOrdinal(a, b);
            return a.Length - b.Length;
        });
        Console.WriteLine(string.Join("\n", unsorted));
        // your code goes here
    }
}

/***********************************************************
 * Intro to Tutorial Challenges
 * *********************************************************/
 using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int v = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        string[] strs = Console.ReadLine().Split(' ');
        // Console.WriteLine(strs.Length);
        int ret = -1;
        for (int i = 0; i < n; i++) {
            int iVal;
            int.TryParse(strs[i], out iVal);

            if (iVal == v) {
                ret = i;
                break;
            }
        }
        Console.WriteLine(ret);
    }
}

/***********************************************************
 * Insertion Sort - Part 1
 * *********************************************************/
 using System;
using System.Collections.Generic;
using System.IO;
class Solution {

    static void printArray(int[] ar) {

        foreach (var i in ar) {
            Console.Write(i.ToString() + " ");
        }
        Console.WriteLine();
    }
    static void insertionSort(int[] ar) {
        int n = ar.Length;
        int v = ar[n - 1];
        int curr = n - 1;
        for (int i = n - 1; i > 0; i--) {
            if (ar[i - 1] > v) {
                ar[i] = ar[i - 1];
            } else {
                ar[i] = v;
                break;
            }
            printArray(ar);

        }
        if (ar[0] > v)
            ar[0] = v;
        printArray(ar);
    }
    /* Tail starts here */
    static void Main(String[] args) {

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++) {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        insertionSort(_ar);
    }

}
    /***********************************************************
 * Insertion Sort - Part 2
 * *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
class Solution {

    static void sortArrayStartWith(int[] ar, ref int pos) {

        int n = ar.Length;
        if (pos == n)
            return;
        if (pos > 0) {
            // Console.WriteLine("curr pos is "+ pos.ToString());
            int currPos = pos;
            while (currPos > 0) {
                if (ar[currPos] < ar[currPos - 1]) {
                    int tmp = ar[currPos];
                    ar[currPos] = ar[currPos - 1];
                    ar[currPos - 1] = tmp;
                }
                currPos--;
            }
            for (int i = 0; i < n; i++) {
                Console.Write(string.Format("{0} ", ar[i]));

            }
            Console.WriteLine();
        }
        pos++;
        sortArrayStartWith(ar, ref pos);

    }
    static void insertionSort(int[] ar) {
        int pos = 0;
        sortArrayStartWith(ar, ref pos);

    }
    static void Main(String[] args) {

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++) {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        insertionSort(_ar);
    }
}
/***********************************************************
* Running Time of Algorithms
* *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static void sortArrayStartWith(int[] ar, ref int pos, ref int totalShifts) {

        int n = ar.Length;
        if (pos == n)
            return;
        if (pos > 0) {
            // Console.WriteLine("curr pos is "+ pos.ToString());
            int currPos = pos;
            while (currPos > 0) {
                if (ar[currPos] < ar[currPos - 1]) {
                    totalShifts++;
                    int tmp = ar[currPos];
                    ar[currPos] = ar[currPos - 1];
                    ar[currPos - 1] = tmp;
                }
                currPos--;
            }
            //  for(int i=0;i<n;i++)    {
            //      Console.Write(string.Format("{0} ",ar[i]));

            //  }
            //  Console.WriteLine();
        }
        pos++;
        sortArrayStartWith(ar, ref pos, ref totalShifts);

    }
    static void insertionSort(int[] ar) {
        int pos = 0;
        int totalShifts = 0;
        sortArrayStartWith(ar, ref pos, ref totalShifts);
        Console.WriteLine(totalShifts.ToString());
    }


    static void Main(String[] args) {
        int arSize = Convert.ToInt32(Console.ReadLine());
        string[] strs = Console.ReadLine().Split(' ');
        int[] ivals = new int[arSize];
        for (int i = 0; i < arSize; i++)
            ivals[i] = Convert.ToInt32(strs[i]);
        insertionSort(ivals);
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    }
}
/***********************************************************
* Quicksort 1 - Partition
* *********************************************************/

    using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void printArray(int[] ar) {
        foreach (var i in ar)
            Console.Write("{0} ", i);
    }
    static void partition(int[] ar) {
        List<int> leftL = new List<int>();
        List<int> rightL = new List<int>();
        List<int> equalL = new List<int>();
        int pivot = ar[0];
        int n = ar.Length;
        equalL.Add(pivot);
        for (int i = 1; i < n; i++) {
            int val = ar[i];
            if (val < pivot)
                leftL.Add(val);
            else if (val > pivot)
                rightL.Add(val);
            else
                equalL.Add(val);
        }
        printArray(leftL.ToArray());
        printArray(equalL.ToArray());
        printArray(rightL.ToArray());

    }
    /* Tail starts here */
    static void Main(String[] args) {

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++) {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        partition(_ar);
    }
}

/***********************************************************
* Counting Sort 1
* *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int N = Convert.ToInt32(Console.ReadLine());
        string[] strs = Console.ReadLine().Split(new char[] { ' ' });
        int[] ivals = strs.Select(int.Parse).ToArray();

        int[] counts = new int[N];
        for (int i = 0; i < N; i++) {
            counts[i] = 0; ;
        }
        for (int i = 0; i < N; i++) {
            int val = ivals[i];
            counts[val] = counts[val] + 1;
            //Console.WriteLine("Value of {0} is {1}",val,counts[val]);
        }
        for (int i = 0; i < 100; i++) {
            Console.Write(string.Format("{0} ", counts[i]));

        }
    }
}

/***********************************************************
* Counting Sort 2
* *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int N = Convert.ToInt32(Console.ReadLine());
        string[] strs = Console.ReadLine().Split(new char[] { ' ' });
        int[] ivals = strs.Select(int.Parse).ToArray();

        int[] counts = new int[N];
        for (int i = 0; i < N; i++) {
            counts[i] = 0; ;
        }
        for (int i = 0; i < N; i++) {
            int val = ivals[i];
            counts[val] = counts[val] + 1;
            //Console.WriteLine("Value of {0} is {1}",val,counts[val]);
        }
        for (int i = 0; i < 100; i++) {
            int val = counts[i];
            //Console.WriteLine("Value of "+ i +" is "+val.ToString());
            if (val == 0)
                continue;
            for (int j = 0; j < val; j++)
                Console.Write(string.Format("{0} ", i));

        }
    }
}


/***********************************************************
* The Full Counting Sort -Revisit Timing issue for Test case # 5
* *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int N = Convert.ToInt32(Console.ReadLine());
        string[] counts = new string[N];
        int[] resets = new int[N];
        int halfSize = N / 2;
        for (int i = 0; i < N; i++) {
            string[] strs = Console.ReadLine().Split(new char[] { ' ' });
            int index = Convert.ToInt32(strs[0]);
            string sval = strs[1];
            //  counts[index]+=sval+" ";
            if (i < halfSize) {
                resets[index]++;
                counts[index] += "-" + " ";
            } else {
                counts[index] += sval + " ";
            }
        }
        if (N > 100)
            N = 100;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < N; i++) {
            if (string.IsNullOrEmpty(counts[i]))
                continue;
            sb.Append(counts[i]);

        }
        Console.WriteLine(sb.ToString());
    }
}

    
/***********************************************************
* Closest Numbers
* *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int N = Convert.ToInt32(Console.ReadLine());
        string[] strs = Console.ReadLine().Split(new char[] { ' ' });
        long[] ivals = strs.Select(long.Parse).ToArray();
        Array.Sort(ivals);
        long minDiff = long.MaxValue;
        List<long> nums = new List<long>();
        for (int i = 1; i < N; i++) {
            long diff = Math.Abs(ivals[i] - ivals[i - 1]);
            if (diff < minDiff) {
                minDiff = diff;
                nums.Clear();
                nums.Add(ivals[i - 1]);
                nums.Add(ivals[i]);
            } else if (diff == minDiff) {
                nums.Add(ivals[i - 1]);
                nums.Add(ivals[i]);
            }

        }
        StringBuilder sb = new StringBuilder();
        nums.ForEach(x => sb.Append(x.ToString() + " "));
        Console.WriteLine(sb.ToString());
    }
}
/***********************************************************
* Insertion Sort Advanced Analysis`- Timing out- see editorial notes
* *********************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void sortArrayStartWith(int[] ar, ref int pos, ref int totalShifts) {

        int n = ar.Length;
        if (pos == n)
            return;
        if (pos > 0) {
            // Console.WriteLine("curr pos is "+ pos.ToString());
            int currPos = pos;
            while (currPos > 0) {
                if (ar[currPos] < ar[currPos - 1]) {
                    totalShifts++;
                    int tmp = ar[currPos];
                    ar[currPos] = ar[currPos - 1];
                    ar[currPos - 1] = tmp;
                }
                currPos--;
            }
            //  for(int i=0;i<n;i++)    {
            //      Console.Write(string.Format("{0} ",ar[i]));

            //  }
            //  Console.WriteLine();
        }
        pos++;
        sortArrayStartWith(ar, ref pos, ref totalShifts);

    }
    static void insetionSortOtherWay(int[] A) {
        int totalShifts = 0;
        var j = 0;
        for (var i = 1; i < A.Length; i++) {

            var value = A[i];
            j = i - 1;
            while (j >= 0 && value < A[j]) {
                A[j + 1] = A[j];
                j = j - 1;
                totalShifts++;
            }
            A[j + 1] = value;

        }
        Console.WriteLine(totalShifts);
    }
    static void insertionSort(int[] ar) {
        int pos = 0;
        int totalShifts = 0;
        sortArrayStartWith(ar, ref pos, ref totalShifts);
        Console.WriteLine(totalShifts.ToString());
    }

    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int q = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < q; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] strs = Console.ReadLine().Split(' ');
            int[] ivals = strs.Select(int.Parse).ToArray();
            insetionSortOtherWay(ivals);
        }
    }
}