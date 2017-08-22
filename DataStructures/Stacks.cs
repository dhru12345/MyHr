/******************************************************************************************
-- Stacks- Timeout on Test cases
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Stack<long> mystack = new Stack<long>();
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++) {
            string str = Console.ReadLine();
            // Console.WriteLine(str);
            var arr = str.Split(new char[] { ' ' });
            long[] iArr = arr.Select(long.Parse).ToArray();
            if (iArr[0] == 1) {
                if (mystack.Count() <= 0)
                    mystack.Push(iArr[1]);
                else {
                    mystack.Push(Math.Max(iArr[1], mystack.Peek()));
                }
            } else if (iArr[0] == 2) {
                mystack.Pop();
            } else if (iArr[0] == 3) {
                Console.WriteLine(mystack.Peek());
            }
        }
    }
}

/******************************************************************************************
-- Balanced Brackets
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static char matched(char c) {
        if (c == '}')
            return '{';
        else if (c == ']')
            return '[';
        else if (c == ')')
            return '(';
        else
            return 'X';

    }
    static string isBalanced(string s) {
        // Complete this function
        Stack<char> st = new Stack<char>();
        for (int i = 0; i < s.Length; i++) {
            //Console.WriteLine(s[i]);
            if (st.Count() == 0) {
                st.Push(s[i]);
                //  Console.WriteLine("Pushed");
            } else {
                char peekc = st.Peek();
                char match = matched(s[i]);
                //Console.WriteLine(string.Format("{0} {1}",peekc,match));
                if (peekc == match) {
                    st.Pop();
                    //  Console.WriteLine("Poped");
                } else {
                    st.Push(s[i]);
                    // Console.WriteLine("Pushed");
                }
            }
        }
        return st.Count() == 0 ? "YES" : "NO";
    }

    

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++) {
            string s = Console.ReadLine();
            // Console.WriteLine(s);
            string result = isBalanced(s);
            Console.WriteLine(result);
        }
    }
}

/******************************************************************************************
-- Equal Stacks
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static int sumOfStack(Stack<int> stack) {
        int ret = 0;
        stack.ToList().ForEach(x => ret += x);
        return ret;
    }
    static void Main(String[] args) {
        string[] tokens_n1 = Console.ReadLine().Split(' ');
        int n1 = Convert.ToInt32(tokens_n1[0]);
        int n2 = Convert.ToInt32(tokens_n1[1]);
        int n3 = Convert.ToInt32(tokens_n1[2]);
        string[] h1_temp = Console.ReadLine().Split(' ');
        int[] h1 = Array.ConvertAll(h1_temp, Int32.Parse);
        string[] h2_temp = Console.ReadLine().Split(' ');
        int[] h2 = Array.ConvertAll(h2_temp, Int32.Parse);
        string[] h3_temp = Console.ReadLine().Split(' ');
        int[] h3 = Array.ConvertAll(h3_temp, Int32.Parse);

        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();
        Stack<int> stack3 = new Stack<int>();
        for (int i = n1 - 1; i >= 0; i--) {
            stack1.Push(h1[i]);
        }
        for (int i = n2 - 1; i >= 0; i--) {
            stack2.Push(h2[i]);
        }
        for (int i = n3 - 1; i >= 0; i--) {
            stack3.Push(h3[i]);
        }
        int sumS1 = sumOfStack(stack1);
        int sumS2 = sumOfStack(stack2);
        int sumS3 = sumOfStack(stack3);

        while (!(sumS1 == sumS2 && sumS2 == sumS3)) {
            if (sumS1 > sumS2 || sumS1 > sumS3) {
                int t = (int)stack1.Pop();
                sumS1 -= t;
            }
            if (sumS2 > sumS1 || sumS2 > sumS3) {
                int t = (int)stack2.Pop();
                sumS2 -= t;
            }
            if (sumS3 > sumS2 || sumS3 > sumS1) {
                int t = (int)stack3.Pop();
                sumS3 -= t;
            }
        }
        Console.WriteLine(sumOfStack(stack1));
        // Console.WriteLine(sumOfStack(stack2));
        //  Console.WriteLine(sumOfStack(stack3));
    }
}
/******************************************************************************************
--  Game of Two Stacks - TEST failing
*******************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int g = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < g; a0++) {
            string str = Console.ReadLine();
            string[] tokens_n = str.Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            int x = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            string[] b_temp = Console.ReadLine().Split(' ');
            int[] b = Array.ConvertAll(b_temp, Int32.Parse);
            Stack<long> s1 = new Stack<long>();
            Stack<long> s2 = new Stack<long>();
            // Console.WriteLine("Processing "+str);
            for (int i = n - 1; i >= 0; i--)
                s1.Push(a[i]);
            for (int i = m - 1; i >= 0; i--)
                s2.Push(b[i]);
            bool done = false;
            long iTry = 0;
            long totalSum = 0;
            while (!done) {
                bool didPop = false;
                if (s1.Count() == 0 && s2.Count() == 0) {
                    done = true;
                } else if ((s1.Count() > 0 && s2.Count() <= 0)) {
                    if ((totalSum + s1.Peek()) <= x) {
                        totalSum += s1.Peek();
                        s1.Pop();
                        iTry++;
                        didPop = true;
                    }
                } else if (s1.Count() > 0 && s2.Count() > 0 && (s1.Peek() <= s2.Peek())) {
                    if ((totalSum + s1.Peek()) <= x) {
                        totalSum += s1.Peek();
                        s1.Pop();
                        iTry++;
                        didPop = true;
                    }
                } else if ((s1.Count() <= 0 && s2.Count() > 0)) {
                    if ((totalSum + s2.Peek()) <= x) {
                        totalSum += s2.Peek();
                        s2.Pop();
                        didPop = true;
                        iTry++;
                    }
                } else if (s1.Count() > 0 && s2.Count() > 0 && (s2.Peek() < s1.Peek())) {
                    if ((totalSum + s2.Peek()) <= x) {
                        totalSum += s2.Peek();
                        s2.Pop();
                        didPop = true;
                        iTry++;
                    }
                }
                if (!didPop)
                    break;
            }
            Console.WriteLine(iTry);
        }
    }
}
/******************************************************************************************
--  Largest Rectangle - TEST failing
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void printArray(int[] h, int x) {
        Console.WriteLine();
        for (int i = 0; i < x; i++) {
            Console.Write(h[i]);
            Console.Write(' ');
        }
    }
    static long largestRectangle(int[] h, int x) {

        List<int> height = new List<int>();
        height.AddRange(h);
        int maxArea = 0;
        var mystack = new Stack<int>();

        for (var i = 0; i < height.Count; i++) {
            while (mystack.Count > 0 && height[i] <= height[mystack.Peek()]) {
                var top = mystack.Pop();
                var prelessHeight = mystack.Count == 0 ? -1 : mystack.Peek();

                maxArea = Math.Max(maxArea, height[top] * (i - prelessHeight - 1));
            }

            mystack.Push(i);
        }

        int lastIndex = mystack.Any() ? mystack.Peek() : -1;
        while (mystack.Any()) {
            var top = mystack.Pop();
            int prelessHeight = mystack.Count == 0 ? -1 : mystack.Peek();

            maxArea = Math.Max(maxArea, height[top] * (lastIndex - prelessHeight));
        }

        return maxArea;

    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] h_temp = Console.ReadLine().Split(' ');
        int[] h = Array.ConvertAll(h_temp, Int32.Parse);
        long result = largestRectangle(h, n);
        Console.WriteLine(result);
    }
}
