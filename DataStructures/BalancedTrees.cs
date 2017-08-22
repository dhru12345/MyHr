
/******************************************************************************************
-- Self Balancing Tree?
*******************************************************************************************/
/* Node is defined as :
typedef struct node
{
    int val;
    struct node* left;
    struct node* right;
    int ht;
} node; */

node* create_node(int val) {
    node* n = (node*)malloc(sizeof(node));
    n->val = val;
    n->left = NULL;
    n->right = NULL;
    n->ht = 0;
    return n;
}

int height(node* n) {
    if (n == NULL) {
        return -1;
    }
    return n->ht;
}

int calculate_height(node* n) {
    return 1 + max(height(n->left), height(n->right));
}

int weight(node* n) {
    if (n == NULL) {
        return 0;
    }
    return height(n->left) - height(n->right);
}

node* right_rotate(node* root) {
    node* oldRoot = root;
    root = oldRoot->left;
    oldRoot->left = root->right;
    root->right = oldRoot;

    oldRoot->ht = calculate_height(oldRoot);
    root->ht = calculate_height(root);

    return root;

}

node* left_rotate(node* root) {
    node* oldRoot = root;
    root = oldRoot->right;
    oldRoot->right = root->left;
    root->left = oldRoot;

    oldRoot->ht = calculate_height(oldRoot);
    root->ht = calculate_height(root);

    return root;
}

node* balance(node* root) {
    int w = weight(root);

    if (root == NULL || abs(w) <= 1) {
        return root;
    }

    if (w > 0) {
        if (weight(root->left) < 0) {
            root->left = left_rotate(root->left);
        }
        return right_rotate(root);
    } else {
        if (weight(root->right) > 0) {
            root->right = right_rotate(root->right);
        }
        return left_rotate(root);
    }

    return root;
}
node* insert(node* root, int val) {
    if (val < root->val) {
        if (root->left == NULL) {
            root->left = create_node(val);
        } else {
            root->left = insert(root->left, val);
        }
    } else if (val > root->val) {
        if (root->right == NULL) {
            root->right = create_node(val);
        } else {
            root->right = insert(root->right, val);
        }
    }

    root->ht = calculate_height(root);

    return balance(root);

}
bool trees_equal(node* n1, node* n2) {
    if (n1 == NULL && n2 == NULL) {
        return true;
    } else if (n1 == NULL || n2 == NULL || n1->val != n2->val) {
        return false;
    }

    return trees_equal(n1->left, n2->left) && trees_equal(n1->right, n2->right);
}


/******************************************************************************************
-- Array and simple queries - Getting Time out on Test queries
*******************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void shuffleList(ref List<int> list, int[] tmpArr) {
        List<int> tmpList = new List<int>();
        for (int i = tmpArr[1]; i <= tmpArr[2]; i++) {
            tmpList.Add(list[tmpArr[1] - 1]);
            list.RemoveAt(tmpArr[1] - 1);

        }
        // printList(list);
        if (tmpArr[0] == 1) {
            list.InsertRange(0, tmpList);
        } else if (tmpArr[0] == 2) {
            list.AddRange(tmpList);
        }
    }
    static void printList(List<int> list) {
        // Console.WriteLine(list.Count);
        for (int i = 0; i < list.Count; i++) {
            Console.Write(string.Format("{0}{1}", list[i], ' '));
        }
        // Console.WriteLine();
    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string[] vals = Console.ReadLine().Split(new char[] { ' ' });
        int n = Convert.ToInt32(vals[0]);
        int m = Convert.ToInt32(vals[1]);
        // Console.WriteLine(n);
        // Console.WriteLine(m);
        string str = Console.ReadLine();
        // Console.WriteLine(str);
        string[] arrstr = str.Split(new char[] { ' ' });

        List<int> list = new List<int>();
        for (int i = 0; i < n; i++) {
            //  Console.Write(arrstr[i]);
            list.Add(Convert.ToInt32(arrstr[i]));
        }

        //printList(list);
        for (int i = 0; i < m; i++) {
            arrstr = Console.ReadLine().Split(new char[] { ' ' });
            int[] tmpArr = new int[3];
            for (int j = 0; j < 3; j++) {
                tmpArr[j] = Convert.ToInt32(arrstr[j]);
            }
            // Console.WriteLine();
            // printList(list);
            shuffleList(ref list, tmpArr);
            //  printList(list);
        }
        Console.WriteLine(Math.Abs(list[0] - list[list.Count - 1]));
        printList(list);
    }
}