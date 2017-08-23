/******************************************************************************************
Queue using Two Stacks
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Queue<long> myq = new Queue<long>();
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++) {
            string str = Console.ReadLine();
            // Console.WriteLine(str);
            var arr = str.Split(new char[] { ' ' });
            long[] iArr = arr.Select(long.Parse).ToArray();
            if (iArr[0] == 1) {
                myq.Enqueue(iArr[1]);
            } else if (iArr[0] == 2) {
                myq.Dequeue();
            } else if (iArr[0] == 3) {
                Console.WriteLine(myq.Peek());
            }
        }
    }
}
/******************************************************************************************
Castle on the Grid
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    public class Point {
        int _x;
        int _y;
        public Point() {

        }
        public Point(int a, int b) {
            _x = a;
            _y = b;
        }
        public int x { get { return _x; } }
        public int y { get { return _y; } }
    }
    static List<Point> pointFromPoint(int N, string[,] grid, Point point) {
        int x = point.x;
        int y = point.y;
        List<Point> points = new List<Point>();
        while (x > 0) {
            x -= 1;
            if (grid[x, y] == "X")
                break;
            points.Add(new Point(x, y));
        }
        x = point.x;
        while (x < N - 1) {
            x += 1;
            if (grid[x, y] == "X")
                break;
            points.Add(new Point(x, y));
        }
        x = point.x;
        while (y > 0) {
            y -= 1;
            if (grid[x, y] == "X")
                break;
            points.Add(new Point(x, y));
        }
        y = point.y;
        while (y < N - 1) {
            y += 1;
            if (grid[x, y] == "X")
                break;
            points.Add(new Point(x, y));
        }
        return points;
    }
    static int minimumMoves(int N, string[,] grid, int startX, int startY, int goalX, int goalY) {
        List<Point> q = new List<Point>();

        Point start = new Point(startX, startY);
        Point end = new Point(goalX, goalY);
        q.Add(start);
        grid[startX, startY] = "0";
        while (q.Count() > 0) {
            var currPoint = q[q.Count() - 1];//q.Dequeue();
            q.RemoveAt(q.Count() - 1);
            var currdist = Convert.ToInt32(grid[currPoint.x, currPoint.y]);
            var points = pointFromPoint(N, grid, currPoint);
            foreach (var p in points) {
                if (grid[p.x, p.y] == ".") {
                    grid[p.x, p.y] = (currdist + 1).ToString();
                    q.Insert(0, p);
                    if (p.x == end.x && p.y == end.y)
                        return Convert.ToInt32(currdist) + 1;
                }
            }
        }
        // Complete this function
        return -1;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine(n);
        string[,] grid = new string[n, n];
        for (int i = 0; i < n; i++) {
            string str = Console.ReadLine();
            for (int j = 0; j < n; j++)
                grid[i, j] = str[j].ToString();
            // Console.WriteLine(str+ "Length" + str.Length.ToString());
            // grid[i]=str;
        }

        string[] tokens_startX = Console.ReadLine().Split(' ');
        //  foreach(var str in tokens_startX){
        //     Console.Write(str+" ");
        //  }
        int startX = Convert.ToInt32(tokens_startX[0]);
        int startY = Convert.ToInt32(tokens_startX[1]);
        int goalX = Convert.ToInt32(tokens_startX[2]);
        int goalY = Convert.ToInt32(tokens_startX[3]);
        int result = minimumMoves(n, grid, startX, startY, goalX, goalY);
        Console.WriteLine(result);

    }
}
/******************************************************************************************
Down to Zero || Some test case are failing
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static List<bool> vis = new List<bool>();
    static void InitVis() {
        vis = new List<bool>();
        for (int i = 0; i < 1001010; i++) {
            vis.Add(false);
        }
    }
    static void bfs(ref Tuple<int, int> curr, ref Queue<Tuple<int, int>> q) {


        int m = curr.Item1;
        for (int i = 2; i <= Math.Sqrt(m); i++) {
            if (m % i == 0) {
                int nxt = Math.Max(i, m / i);
                if (!vis[nxt]) {
                    vis[nxt] = true;
                    q.Enqueue(Tuple.Create(nxt, curr.Item2 + 1));
                }
            }
        }
        if (m > 0 && !vis[m - 1]) {
            vis[m - 1] = true;
            q.Enqueue(Tuple.Create(m - 1, curr.Item2 + 1));
        }
    }
    static void Main(String[] args) {
        int Q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < Q; a0++) {
            int N = Convert.ToInt32(Console.ReadLine());
            //  Console.WriteLine(N);
            InitVis();
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            int ans = 0;
            q.Enqueue(Tuple.Create(N, 0));
            while (q.Count() > 0) {
                var curr = q.Dequeue();
                if (curr.Item1 == 0) {
                    ans = curr.Item2;
                    break;
                }
                bfs(ref curr, ref q);
            }
            Console.WriteLine(ans);
        }
    }
}
/******************************************************************************************
Truck Tour
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    struct Station {
        public long fuel;
        public long distance;
    }
    static bool checkPath(List<Station> list, int start, int N) {
        long fuel = 0;
        long i = start;
        while (i < N) {

            fuel += list[(int)i].fuel;
            fuel -= list[(int)i].distance;

            if (fuel < 0)
                return false;
            i++;
            if (start > 0) {
                if (i == start)
                    return true;
                else if (i == N)
                    i = 0;
            }
        }
        return true;
    }
    static void Main(String[] args) {
        List<Station> list = new List<Station>();
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++) {
            string str = Console.ReadLine();
            string[] strs = str.Split(new char[] { ' ' });

            Station st = new Station();
            st.fuel = Convert.ToInt32(strs[0]);
            st.distance = Convert.ToInt32(strs[1]);
            list.Add(st);

        }

        // Console.WriteLine(str+ "Length" + str.Length.ToString());
        // grid[i]=str;
        int rot = -1;
        while (rot++ < n) {
            if (checkPath(list, rot, n))
                break;
        }
        Console.WriteLine(rot);
    }
}

    /******************************************************************************************
Queries with Fixed Length -Time out in test
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static long searchArr(int n, long[] values, int d) {
        List<Tuple<int, int>> list = new List<Tuple<int, int>>();
        List<long> maxVals = new List<long>();

        for (int i = 0; i < n; i++) {

            if ((i + d - 1) <= n - 1) {
                int start = i;
                int end = i + d - 1;
                long mx = values.Skip(start).Take(d).Max();

                maxVals.Add(mx);

            }

        }
        return maxVals.Min();
    }

    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string str = Console.ReadLine();
        string[] strs = str.Split(new char[] { ' ' });
        int n = Convert.ToInt32(strs[0]);
        int d = Convert.ToInt32(strs[1]);
        // Console.WriteLine(n);
        // Console.WriteLine(d);
        str = Console.ReadLine();
        // Console.WriteLine(str);
        strs = str.Split(new char[] { ' ' });
        long[] values = Array.ConvertAll(strs, long.Parse);
        for (int i = 0; i < d; i++) {
            str = Console.ReadLine();
            int dval = Convert.ToInt32(str);
            //List<Tuple<int, int>> searchList = searchArr(n, values, dval);
            //List<long> finalValues = getMaxValues(searchList, values);
            //long result = finalValues.Min();
            long result = searchArr(n, values, dval);
            Console.WriteLine(result);
        }
    }
}