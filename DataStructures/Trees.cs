
/******************************************************************************************
-- Tree: Preorder Traversal
*******************************************************************************************/
* /* you only have to complete the function given below.  
Node is defined as  

struct node
{
    int data;
    node* left;
    node* right;
};

*/

void preOrder(node* root) {
    node* n = root;
    if (n == NULL)
        return;
    cout << n->data;
    cout << ' ';
    preOrder(n->left);
    preOrder(n->right);
    return;
}

/******************************************************************************************
-- Tree: Postorder Traversal
*******************************************************************************************/
/* you only have to complete the function given below.  
Node is defined as  

struct node
{
    int data;
    node* left;
    node* right;
};

*/


void postOrder(node* root) {
    node* n = root;
    if (n == NULL)
        return;
    postOrder(n->left);
    postOrder(n->right);
    cout << n->data << " ";
}

/******************************************************************************************
-- Tree: Inorder Traversal
*******************************************************************************************/
/* you only have to complete the function given below.  
Node is defined as  

struct node
{
    int data;
    node* left;
    node* right;
};

*/

void inOrder(node* root) {
    node* n = root;
    if (n == NULL)
        return;
    inOrder(n->left);
    cout << n->data << " ";
    inOrder(n->right);

}
/******************************************************************************************
-- Tree: Height of a Binary Tree
*******************************************************************************************/
/*The tree node has data, left child and right child 
class Node {
    int data;
    Node* left;
    Node* right;
};

*/
int height(Node* root) {
    // Write your code here.
    if (root == NULL)
        return -1;
    return max(height(root->left) + 1, height(root->right) + 1);
}
/******************************************************************************************
-- Tree : Top View
*******************************************************************************************/
/*
struct node
{
    int data;
    node* left;
    node* right;
};

*/
/*
Top view tree should have all top level left and all top level right  children of root node
*/
void topViewLeft(node* root) {
    node* n = root;

    if (n == NULL)
        return;
    topViewLeft(n->left);
    cout << n->data << " ";
}
void topViewRight(node* root) {
    node* n = root;

    if (n == NULL)
        return;
    cout << n->data << " ";
    topViewRight(n->right);

}
void topView(node* root) {
    node* n = root;

    if (n == NULL)
        return;
    topViewLeft(n);
    topViewRight(n->right);

}
/******************************************************************************************
-- Tree: Level Order Traversal
*******************************************************************************************/

/*
struct node
{
    int data;
    node* left;
    node* right;
}*/
int height(node* root) {
    if (root == NULL) return 0;
    int heit = max(height(root->left), height(root->right));
    return heit + 1;
}
void printLevel(node* root, int level) {
    if (root == NULL) return;
    else if (level == 1) cout << root->data << " ";
    else {
        printLevel(root->left, level - 1);
        printLevel(root->right, level - 1);
    }
}
void levelOrder(node* root) {
    int heit = height(root);
    for (int i = 1; i <= heit; i++) {
        printLevel(root, i);
    }
}

/*
Node is defined as 

typedef struct node
{
   int data;
   node * left;
   node * right;
}node;

*/

/******************************************************************************************
-- Binary Search Tree : Insertion
*******************************************************************************************/
node* insert(node* root, int value) {

    if (root == NULL) {
        root = new node();
        root->data = value;
        return root;
    }
    if (value < root->data) {
        root->left = insert(root->left, value);
    } else
        root->right = insert(root->right, value);

    return root;
}

/******************************************************************************************
-- Is This a Binary Search Tree?
*******************************************************************************************/
/* Hidden stub code will pass a root argument to the function below. Complete the function to solve the challenge. Hint: you may want to write one or more helper functions.  

The Node struct is defined as follows:
   struct Node {
      int data;
      Node* left;
      Node* right;
   }
*/

vector<int> nodes;
void inOrderTraversal(Node* node) {
    if (node == NULL) {
        return;
    }
    inOrderTraversal(node->left);
    nodes.push_back(node->data);
    inOrderTraversal(node->right);
}

bool checkBST(Node* root) {
    inOrderTraversal(root);
    for (int i = 1; i < nodes.size(); i++) {
        if (nodes[i] <= nodes[i - 1]) {
            return false;
        }
    }
    return true;

}
