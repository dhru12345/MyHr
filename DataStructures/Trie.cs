/******************************************************************************************
Contacts
 //https://www.youtube.com/watch?v=vlYZb68kAY0
https://visualstudiomagazine.com/Articles/2015/10/20/Text-Pattern-Search-Trie-Class-NET.aspx?Page=2
*******************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    class Node {
        //https://www.youtube.com/watch?v=vlYZb68kAY0
        const int TOTAL_CHAR = 26;
        Node[] children = new Node[TOTAL_CHAR];
        int size = 0;
        private int getCharIndex(char c) {
            return c - 'a';
        }
        private Node getNode(char c) {
            return children[getCharIndex(c)];
        }
        private void setNode(char c, Node node) {
            children[getCharIndex(c)] = node;
        }
        public void add(string s) {
            add(s, 0);
        }
        public void add(string s, int index) {
            size++;
            if (index == s.Length)
                return;
            char current = s[index];
            // int charCode=getCharIndex(current);
            Node child = getNode(current);
            if (child == null) {
                child = new Node();
                setNode(current, child);
            }
            child.add(s, index + 1);
        }
        public int findCount(string s, int index) {
            if (index == s.Length)
                return size;


            Node child = getNode(s[index]);
            if (child == null)
                return 0;
            return child.findCount(s, index + 1);
        }

    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        List<string> list = new List<string>();
        Node root = new Node();

        for (int i = 0; i < n; i++) {
            string[] strs = Console.ReadLine().Split(new char[] { ' ' });
            if (strs[0] == "add") {
                root.add(strs[1]);
            } else if (strs[0] == "find") {
                int result = root.findCount(strs[1], 0);
                Console.WriteLine(result);
            }
        }
    }
}