
/******************************************************************************************
-- Arrays -DS
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
         for (int i=n-1;i>=0;i--){
            if (i!=n-1)
                Console.Write(' ');
            Console.Write(arr[i]);
        }
    }
}
/******************************************************************************************
-- 2D Array - DS
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static int sumOfHG(int[][]arr){
            int rowCount = arr.Length - 2;
            int maxSum = int.MinValue;
            for (int i = 0; i < rowCount; i++)
            {
              
                int columnCount = arr[i].Length - 2;
                for (int j = 0; j < columnCount; j++)
                {
                  
                    int sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                                            + arr[i + 1][j + 1]
                            + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
    }
    static void Main(String[] args) {
        int[][] arr = new int[6][];
        int imax=0;
        int iTemp=0;
        for(int arr_i = 0; arr_i < 6; arr_i++){
           string[] arr_temp = Console.ReadLine().Split(' ');
           arr[arr_i] = Array.ConvertAll(arr_temp,Int32.Parse);
        }
        imax=sumOfHG(arr);
        Console.WriteLine(imax);
        Console.ReadKey();
    }
}

/******************************************************************************************
-- Dynamic Array
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
         string[] arr_temp = Console.ReadLine().Split(' ');
            long[] arr = Array.ConvertAll(arr_temp,long.Parse);
            long N = arr[0];
            long[] S = new long[]{0,0,0};
            long Q = arr[1];
            long lastAnswer = 0;
            List<long>[] list=new List<long>[N];
            for(int i=0;i<N;i++)
            {
                list[i] = new List<long>();
            }
            for(int i=0;i<Q;i++)
            {
                string[] qry_temp = Console.ReadLine().Split(' ');
                int[] qry = Array.ConvertAll(qry_temp,Int32.Parse);
                if(qry[0]==1)
                {
                    list[(qry[1] ^ lastAnswer)%N].Add(qry[2]);
                }
                else
                {                    
                    lastAnswer =  list[(qry[1] ^ lastAnswer)%N][qry[2]%(list[(qry[1] ^ lastAnswer)%N].Count)];
                    Console.WriteLine(lastAnswer);
                }

            }
        
    }
}
/******************************************************************************************
-- Left Rotation
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int[] leftRotation(int[] a, int d) {
        // Complete this function
        int n=a.GetLength(0);
        int[] o=new int[n];
        for (int i=0;i<n;i++){
            int newEle=i-d;
            if (newEle<0){
                newEle=n+newEle;
                o[newEle]=a[i];
            }else{
                o[newEle]=a[i];
            }
        }
        return o;
        
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int d = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        int[] result = leftRotation(a, d);
        Console.WriteLine(String.Join(" ", result));


    }
}
/******************************************************************************************
-- Sparse Arrays
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n=Convert.ToInt32(Console.ReadLine().ToString());
        // Console.WriteLine(n);
        Dictionary<string,int> dict=new Dictionary<string,int>();
         List<int> output=new List<int>();
        
        for (int i=0;i<n;i++){
            string str=Console.ReadLine().ToString();
           // Console.WriteLine(str);
            if (dict.ContainsKey(str))
                dict[str]=dict[str]+1;
            else
                dict.Add(str,1);
            
        }
         int q=Convert.ToInt32(Console.ReadLine().ToString());
       // Console.WriteLine(q);
        for (int i=0;i<q;i++){
            int icount=0;
              string str=Console.ReadLine().ToString();
            // Console.WriteLine(str);
             if (dict.ContainsKey(str))
                icount=dict[str];
             output.Add(icount);            
        }
        foreach(var i in output){
            Console.WriteLine(string.Format("{0}",i));
        }
    }
}
/******************************************************************************************
-- Array Manipulation
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        int[] nArray=new int[n];
         for (int i=0;i<n;i++){
            nArray[i]=0;
        }
        for(int a0 = 0; a0 < m; a0++){
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            int k = Convert.ToInt32(tokens_a[2]);
            nArray[a-1]+=k;
            nArray[b-1]+=k;
        }
        int iMax=0;
        for (int i=0;i<n;i++){
           if (nArray[i]>iMax)   
               iMax=nArray[i];
        }
        Console.WriteLine(iMax);
    }
}
/******************************************************************************************
-- Array Manipulation TEST Case failing 
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        long[] nArray=new long[n];
         for (int i=0;i<n;i++){
            nArray[i]=0;
        }
        for(int a0 = 0; a0 < m; a0++){
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            int k = Convert.ToInt32(tokens_a[2]);
            nArray[a-1]+=k;
            nArray[b-1]+=k;
        }
        long iMax=0;
        for (int i=0;i<n;i++){
           if (nArray[i]>iMax)  
               iMax=nArray[i];
        }
        Console.WriteLine(iMax);
    }
}
