

/******************************************************************************************
QHEAP1- Much easier in Java with Priority Queue
*******************************************************************************************/
*using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var t = Convert.ToInt32(Console.ReadLine());
        var commands = new int[t][];

        for (int i = 0; i < t; i++) {
            var segments = Console.ReadLine().Split(' ');
            var command = Convert.ToInt32(segments[0]);
            var argument = command < 3 ? Convert.ToInt32(segments[1]) : -1;

            commands[i] = new int[] { command, argument };
        }

        //Console.SetOut(new StreamWriter(new FileStream("./output.txt", FileMode.OpenOrCreate)));

        var algorithm = new Algorithm();
        algorithm.Process(commands);
    }
    public class Algorithm {
        private MinHeap minHeap = new MinHeap(100);

        public void Process(int[][] commands) {
            foreach (var command in commands) {
                if (command[0] == 1) {
                    minHeap.Insert(command[1]);
                } else if (command[0] == 2) {
                    minHeap.RemoveKey(command[1]);
                } else if (command[0] == 3) {
                    Console.WriteLine(minHeap.Min());
                }
            }
        }
        private class MinHeap {
            private int[] elements;
            private int N = 0;

            public MinHeap(int initialSize) {
                elements = new int[initialSize];
            }

            public void Insert(int key) {
                if (N == elements.Length) Grow();
                elements[N] = key;
                Swim(N);
                N++;
            }

            public int Min() {
                return elements[0];
            }

            public void RemoveKey(int key) {
                RemoveKeyStep(key, 0);
            }

            private bool RemoveKeyStep(int key, int position) {
                if (position >= N || elements[position] > key) {
                    return false;
                }

                if (elements[position] == key) {
                    elements[position] = elements[N - 1];
                    N--;
                    Sink(position);
                    return true;
                }

                var leftChildPosition = position * 2 + 1;
                var rightChildPosition = leftChildPosition + 1;

                var isRemovedInLeft = RemoveKeyStep(key, leftChildPosition);
                var isRemovedInRight = isRemovedInLeft ? false : RemoveKeyStep(key, rightChildPosition);

                return isRemovedInLeft || isRemovedInRight;
            }

            private void Sink(int position) {
                var leftChildPosition = 2 * position + 1;
                var rightChildPosition = leftChildPosition + 1;
                var positionOfSmallest = 0;

                if (leftChildPosition < N && elements[leftChildPosition] < elements[position]) positionOfSmallest = leftChildPosition;
                else positionOfSmallest = position;

                if (rightChildPosition < N && elements[rightChildPosition] < elements[positionOfSmallest]) positionOfSmallest = rightChildPosition;
                if (positionOfSmallest != position) {
                    SwitchElements(position, positionOfSmallest);
                    Sink(positionOfSmallest);
                }
            }

            private void Swim(int position) {
                if (position > 0) {
                    var parentPosition = ((position + 1) / 2) - 1;

                    if (elements[parentPosition] > elements[position]) {
                        SwitchElements(position, parentPosition);
                        Swim(parentPosition);
                    }
                }
            }

            private void SwitchElements(int fromPos, int toPos) {
                var tmpPosition = elements[toPos];
                elements[toPos] = elements[fromPos];
                elements[fromPos] = tmpPosition;
            }

            private void Grow() {
                var newSize = elements.Length * 2;
                var newArray = new int[newSize];

                for (int i = 0; i < N; i++) {
                    newArray[i] = elements[i];
                }

                elements = newArray;
            }
        }
    }
}

/******************************************************************************************
Jesse and Cookies with C++
*******************************************************************************************/
#include <queue>
#include <cstdio>
using namespace std;

int main() {
    int N, K;
    scanf("%d%d", &N, &K);
    priority_queue<int> q;
    for (int i = 0, x; i < N; i++) scanf("%d", &x),q.push(-x);
    for (int n = 0; ; n++) {
        int a = q.top();
        if (-a >= K) {
            printf("%d\n", n);
            break;
        }
        q.pop();
        if (q.empty()) {
            puts("-1");
            break;
        }
        int b = q.top();
        q.pop();
        q.push(a + b * 2);
    }
}
/******************************************************************************************
Find the Running Median
*******************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution {
    class Solution {
        static string findMeadian(List<int> list) {
            decimal ret = 0.0m;
            int count = list.Count();
            if (count == 1)
                ret = list[0];
            else {
                int pos = 0;
                if (count % 2 == 0) {
                    pos = count / 2;
                    ret = (list[pos - 1] + list[pos]) / 2.0m;
                } else {
                    pos = ((count - 1) / 2) + 1;
                    ret = list[pos - 1];
                }
            }
            var ret1 = ret.ToString("0.0");
            return ret1;
        }
        static void Main(string[] args) {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++) {
                int v = Convert.ToInt32(Console.ReadLine());
                list.Add(v);
                list.Sort();
                var result = findMeadian(list);
                Console.WriteLine(result);
            }
        }
    }
}

/******************************************************************************************
Minimum Average Waiting Time
*******************************************************************************************/
#include<iostream>
#include<vector>
#include<algorithm>
#include<queue>
using namespace std;

struct Type {
    int t, l;
};

struct cmp {
    bool operator() (Type& a, Type& b)
	{
		return a.l > b.l;
	}
};

bool operator <(Type a, Type b) {
    return a.t < b.t;
}

vector<Type> v;
priority_queue<Type, vector<Type>, cmp> pq;

int main() {
    int n;
    cin >> n;
    for (int i = 0; i < n; i++) {
        int t, l;
        cin >> t >> l;
        Type tmp; tmp.t = t; tmp.l = l;
        v.push_back(tmp);
    }
    sort(v.begin(), v.end());
    long long cur_t = 0;
    long long tot = 0;
    int idx = 0;

    while (true) {
        int i;
        for (i = idx; i < n; i++) {
            if (v[i].t <= cur_t)
                pq.push(v[i]);
            else {
                idx = i;
                break;
            }
        }

        if (i == n) idx = n;

        if (!pq.empty()) {
            Type tmp = pq.top();
            tot += cur_t + tmp.l - tmp.t;
            cur_t += tmp.l;
            pq.pop();
        } else {
            if (idx != n)
                cur_t = v[idx].t;
        }

        if (idx == n && pq.empty()) break;
    }

    cout << tot / n << endl;
    return 0;
}
