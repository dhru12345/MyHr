/******************************************************************************************
-- Print the Elements of a Linked List
*******************************************************************************************/
*     /*
      Print elements of a linked list on console
      head pointer input could be NULL as well for empty list
      Node is defined as
      class Node {
         int Data;
         Node Next;
      }
    */

    // This is a "method-only" submission.
    // You only need to complete this method.

    public static void Print(Node head) {
    if (head == null)
        return;
    Node temp = head;
    do {
        Console.WriteLine(temp.Data);
        temp = temp.Next;
    } while (temp != null);
}
/******************************************************************************************
-- Insert a Node at the Tail of a Linked List
*******************************************************************************************/
/*
  Insert Node at the end of a linked list
  head pointer input could be NULL as well for empty list
  Node is defined as
  class Node {
     int Data;
     Node Next;
  }
*/
// This is a "method-only" submission.
// You only need to complete this method.

public static Node Insert(Node head, int x) {
    Node ret = new Node();
    ret.Data = x;
    if (head == null)
        return ret;
    else {
        Node last = head;
        while (last.Next != null)
            last = last.Next;
        last.Next = ret;
        return head;
    }
}
/******************************************************************************************
-- Insert a node at the head of a linked list
*******************************************************************************************/
/*
  Insert Node at the beginning of a linked list
  head pointer input could be NULL as well for empty list
  Node is defined as
  class Node {
     int Data;
     Node Next;
  }
*/
// This is a "method-only" submission.
// You only need to complete this method.

public static Node Insert(Node head, int x) {
    Node ret = new Node();
    ret.Data = x;
    if (head == null)
        return ret;
    else {
        ret.Next = head;
        return ret;
    }
}
/******************************************************************************************
--Insert a node at a specific position in a linked list
*************************************************************************************
    /*
      Insert Node at a given position in a linked list
      head can be NULL
      First element in the linked list is at position 0
      Node is defined as
      class Node {
         int Data;
         Node Next;
      }
    */

// This is a "method-only" submission.
// You only need to complete this method.

public static Node InsertNth(Node head, int data, int position) {
    Node node = head;

    if (position == 0) {
        node = new Node();
        node.Data = data;
        node.Next = head;
        return node;
    } else {
        while (--position > 0) {
            node = node.Next;
        }
    }
    Node oldNode = node.Next;
    node.Next = new Node();
    node.Next.Data = data;
    node.Next.Next = oldNode;
    return head;


}
/******************************************************************************************
--Delete a Node
*************************************************************************************
/*
      Delete Node at a given position in a linked list
      head pointer input could be NULL as well for empty list
      Node is defined as
      class Node {
         int Data;
         Node Next;
      }
    */

// This is a "method-only" submission.
// You only need to complete this method.

public static Node Delete(Node head, int position) {
    Node node = head;
    Node prevNode = node;
    if (position == 0) {
        head = head.Next;
        return head;
    } else {
        for (int i = 0; i < position; i++) {
            prevNode = node;
            node = node.Next;
        }
        prevNode.Next = node.Next;
        return head;
    }
}
/******************************************************************************************
--Print in Reverse
*************************************************************************************
/*
      Print linked list from the end to the begin
      head can be NULL
      Node is defined as
      class Node {
         int Data;
         Node Next;
      }
    */

// This is a "method-only" submission.
// You only need to complete this method.

public static void ReversePrint(Node head) {
    if (head == null)
        return;
    ReversePrint(head.Next);
    Console.WriteLine(head.Data);
 }

/******************************************************************************************
--Reverse a linked list (C++)
*************************************************************************************
/*
  Reverse a linked list and return pointer to the head
  The input list will have at least one element  
  Node is defined as 
  struct Node
  {
     int data;
     struct Node *next;
  }
*/
Node* Reverse(Node* head) {
    Node* prev = NULL;
    Node* current = head;
    Node* next;
    while (current != NULL) {
        next = current->next;
        current->next = prev;
        prev = current;
        current = next;
    }
    head = prev;
    return head;
}
/******************************************************************************************
--Compare two linked lists
*************************************************************************************
/*
  Compare two linked lists A and B
  Return 1 if they are identical and 0 if they are not. 
  Node is defined as 
  struct Node
  {
     int data;
     struct Node *next;
  }
*/
int CompareLists(Node* headA, Node* headB) {
    // This is a "method-only" submission. 
    // You only need to complete this method 
    Node* list1 = headA;
    Node* list2 = headB;
    if (list1 == NULL && list2 == NULL)
        return 1;
    if (list1 == NULL && list2 != NULL)
        return 0;
    if (list1 != NULL && list2 == NULL)
        return 0;
    while (list1 != NULL) {
        int d1 = list1->data;
        if (list2 == NULL)
            return 0;
        int d2 = list2->data;
        if (d1 != d2)
            return 0;
        list1 = list1->next;
        list2 = list2 != NULL ? list2->next : NULL;
    }
    if (list2 != NULL)
        return 0;
    return 1;
}
/******************************************************************************************
--Merge two sorted linked lists
*************************************************************************************
/*
  Merge two sorted lists A and B as one linked list
  Node is defined as 
  struct Node
  {
     int data;
     struct Node *next;
  }
*/
Node* MergeLists(Node* headA, Node* headB) {
    // This is a "method-only" submission. 
    // You only need to complete this method 
    if (headA == NULL)
        return headB;
    if (headB == NULL)
        return headA;
    if (headA->data < headB->data) {
        headA->next = MergeLists(headA->next, headB);
        return headA;
    } else {
        headB->next = MergeLists(headA, headB->next);
        return headB;
    }
}
/******************************************************************************************
--Get Node Value
*************************************************************************************
/*
  Get Nth element from the end in a linked list of integers
  Number of elements in the list will always be greater than N.
  Node is defined as 
  struct Node
  {
     int data;
     struct Node *next;
  }
*/
int GetNode(Node* head, int positionFromTail) {
    // This is a "method-only" submission. 
    // You only need to complete this method. 
    int nodes = 0;
    Node* n = head;
    while (n != NULL) {
        nodes++;
        n = n->next;
    }
    nodes = nodes - positionFromTail;
    while (--nodes > 0) {
        head = head->next;
    }
    return head->data;
}
/******************************************************************************************
--Delete duplicate-value nodes from a sorted linked list
*************************************************************************************
/*
  Remove all duplicate elements from a sorted linked list
  Node is defined as 
  struct Node
  {
     int data;
     struct Node *next;
  }
*/
Node* RemoveDuplicates(Node* head) {
    // This is a "method-only" submission. 
    // You only need to complete this method. 
    Node* n = head;
    while (n != NULL) {
        if (n->next == NULL) {
            break;
        }
        if (n->data == n->next->data) {
            n->next = n->next->next;
        } else {
            n = n->next;
        }
    }
    return head;
}
/******************************************************************************************
Cycle Detection
*************************************************************************************
/*
Detect a cycle in a linked list. Note that the head pointer may be 'NULL' if the list is empty.

A Node is defined as: 
    struct Node {
        int data;
        struct Node* next;
    }
*/

bool has_cycle(Node* head) {
    // Complete this function
    // Do not write the main method
    if (head == NULL)
        return false;
    Node* n1 = head;
    Node* n2 = head;
    while (n1 != NULL && n1->next != NULL) {
        n1 = n1->next;
        n2 = n2->next->next;
        if (n1 == NULL || n2 == NULL)
            return false;
        if (n1 == n2)
            return true;
    }
    return false;
}
/******************************************************************************************
Find Merge Point of Two Lists
*************************************************************************************
/*
   Find merge point of two linked lists
   Node is defined as
   struct Node
   {
       int data;
       Node* next;
   }
*/
int FindMergeNode(Node* headA, Node* headB) {
    // Complete this function
    // Do not write the main method. 
    int aLen = 0;
    int bLen = 0;
    Node* ha = headA;
    Node* hb = headB;

    while (ha != NULL) {
        aLen++;
        ha = ha->next;
    }
    while (hb != NULL) {
        bLen++;
        hb = hb->next;
    }
    while (aLen > bLen) {
        headA = headA->next;
        aLen--;
    }
    while (bLen > aLen) {
        headB = headB->next;
        bLen--;
    }
    while (headA != NULL) {
        if (headA == headB) {
            return headA->data;
        }
        headA = headA->next;
        headB = headB->next;
    }
    return -1;
}
/******************************************************************************************
Inserting a Node Into a Sorted Doubly Linked List
*************************************************************************************
/*
    Insert Node in a doubly sorted linked list 
    After each insertion, the list should be sorted
   Node is defined as
   struct Node
   {
     int data;
     Node *next;
     Node *prev;
   }
*/
Node* SortedInsert(Node* head, int data) {
    // Complete this function
    // Do not write the main method. 
    if (head == NULL) {
        Node* node = new Node();
        node->data = data;
        return node;
    }
    Node* node = head;
    while (node != NULL) {
        if (node->data >= data) {
            Node* nn = new Node();
            nn->data = data;
            nn->prev = node->prev;
            nn->next = node;
            node->prev = nn;
            if (nn->prev == NULL)
                return nn;
            else {
                nn->prev->next = nn;
                return head;
            }
        }
        if (node->next == NULL) {
            Node* nn = new Node();
            nn->data = data;
            nn->prev = node;
            nn->next = NULL;
            node->next = nn;
            break;
        }
        node = node->next;
    }
    return head;
}
/******************************************************************************************
Reverse a doubly linked list
*************************************************************************************
/*
   Reverse a doubly linked list, input list may also be empty
   Node is defined as
   struct Node
   {
     int data;
     Node *next;
     Node *prev;
   }
*/
Node* Reverse(Node* head) {
    // Complete this function
    // Do not write the main method. 
    if (head == NULL)
        return NULL;
    while (head != NULL) {
        Node* p = head->prev;
        head->prev = head->next;
        head->next = p;


        if (head->prev == NULL)
            return head;
        head = head->prev;
    }
    return head;
}
