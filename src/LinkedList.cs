using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

public class Node 
{
    public int Data {get;set;}
    public Node Next {get;set;}
    public Node () { }
    public Node (int val) { Data = val; }
}

public class LinkedList 
{
    public Node Head {get;set;}
    public LinkedList() { }

    public void Push (Node node) {
        node.Next = Head;
        Head = node;
    }

    public void InsertSorted (Node headNode, Node nodeToInsert) {
        if (headNode == null) {
            return;
        }

        if (nodeToInsert.Data >= headNode.Data && nodeToInsert.Data <= headNode.Next.Data) {
            Node temp = headNode.Next;
            headNode.Next = nodeToInsert;
            nodeToInsert.Next = temp;
            return;
        }
        else
        {
            InsertSorted(headNode.Next, nodeToInsert);
        }
    }

    public void DeleteNode (Node head, Node delete) {
        if (head.Next == null) {
            return;
        }

        if (head.Next != null && head.Next.Data == delete.Data) {
            Node temp = head.Next.Next != null ? head.Next.Next : null;
            head.Next = temp;
            return;
        }
        else
        {
            DeleteNode(head.Next, delete);
        }
    }


    public LinkedList GetUnion (LinkedList inputList) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        NodeToDict(Head, ref dictionary);
        NodeToDict(inputList.Head, ref dictionary);

        LinkedList unionList = new LinkedList();
        foreach (KeyValuePair<int, int> kvp in dictionary) {
            unionList.Push(new Node(kvp.Key));
        }

        return unionList;
    }

    public LinkedList GetIntersection (LinkedList inputList) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        NodeToDict(Head, ref dictionary);
        NodeToDict(inputList.Head, ref dictionary);

        LinkedList intersectionList = new LinkedList();
        foreach (KeyValuePair<int, int> kvp in dictionary.Where(x => x.Value > 1)) {
            intersectionList.Push(new Node(kvp.Key));
        }

        return intersectionList;
    }

    private void NodeToDict (Node node, ref Dictionary<int, int> dictionary) {
        while (node != null) {
            if (dictionary.TryGetValue(node.Data, out int count)) {
                count += 1;
                dictionary[node.Data] = count;
            }
            else
            {
                dictionary.Add(node.Data, 1);
            }
            node = node.Next;
        }
    }

    //
    // Merge two linked lists in alternating positions
    // If the length of l1 < l2, alternate until the end of l1, and leave the remaining in l2 as is
    public void MergeLinkedListsAtAltPositions (LinkedList inputList) {       
          IterateList(Head, inputList);
    }

    private void IterateList(Node n1, LinkedList inputList) {
        if (n1 == null) {
            return;
        }
        else
        {
            if (inputList.Head == null) { return; }

            Node temp = n1.Next;
            n1.Next = inputList.Head;
            inputList.Head = inputList.Head.Next;
            n1.Next.Next = temp;
            IterateList(n1.Next.Next, inputList);
        }        
    }

    public void PrintList() {
        Node node = Head;
        while (node != null) {
            Console.WriteLine(node.Data);
            node = node.Next;
        }
    }
}

class LinkedListTest
{
    public void Main () {
        LinkedList linkedList = new LinkedList();
        linkedList.Push(new Node(1));
        linkedList.Push(new Node(2));
        linkedList.Push(new Node(3));
        linkedList.Push(new Node(4));
        linkedList.Push(new Node(5));

        LinkedList linkedList2 = new LinkedList();
        linkedList2.Push(new Node(1));
        linkedList2.Push(new Node(2));
        linkedList2.Push(new Node(3));
        linkedList2.Push(new Node(3));
        linkedList2.Push(new Node(3));
        linkedList2.Push(new Node(3));
        linkedList2.Push(new Node(3));
        linkedList2.Push(new Node(3));
        linkedList2.Push(new Node(3));
        
        Node h1 = linkedList.Head;
        Node h2 = linkedList2.Head;

        LinkedList returnList = linkedList.GetIntersection(linkedList2);
        returnList.PrintList();


        // Console.WriteLine("List_1");
        // linkedList.PrintList();
        // Console.WriteLine("List_2");
        // linkedList2.PrintList();

        Console.ReadLine();
    }


    public int CompareTwoListsLexicographically(LinkedList linkedList, LinkedList linkedList2) {
        if (linkedList == linkedList2) {
            return 0;
        }

        Node n1 = linkedList.Head;
        Node n2 = linkedList2.Head;

        while (n1 != null && n2 != null) {
            if (n1.Data == n2.Data) {
                n1 = n1.Next;
                n2 = n2.Next;
                continue;
            }
            else
            {
                if (n1.Data > n2.Data) 
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        if (n1 == n2) {
            return 0;
        }

        if (n1 != null) {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public LinkedList CombineIntRepresentedByLinkedList (LinkedList l1, LinkedList l2) {
        int l1_size = GetSize(l1.Head);
        int l2_size = GetSize(l2.Head);

        LinkedList sum = new LinkedList();
        if (l1_size > l2_size) {
            sum.Head = BuildNodeSumRecursively (l1.Head, 0, l2.Head, l1_size - l2_size);
        }
        else if (l1_size < l2_size) {
            sum.Head = BuildNodeSumRecursively (l1.Head, l1_size - l2_size, l2.Head, 0);
        }
        else
        {
            sum.Head = BuildNodeSumRecursively (l1.Head, 0, l2.Head, 0);
        }

        return sum;
    }

    private Node BuildNodeSumRecursively (Node n1, int p1, Node n2, int p2) {
        Node n = new Node();

        if (n1 == null || n2 == null) {
            return null;
        }

        if (p1 == 0) {
            n.Data += n1.Data;
            n1 = n1.Next;
        }
        else
        {
            p1 -= 1;
        }
        
        if (p2 == 0) {
            n.Data += n2.Data;
            n2 = n2.Next;
        }
        else
        {
            p2 -= 1;
        }

        n.Next = BuildNodeSumRecursively(n1, p1, n2, p2);

        return n;
     }

    public int GetSize (Node node) {
        Node n = node;
        int s = 0;
        while (n != null) {
            n = n.Next;
            s += 1;
        }
        return s;
    }

    public int CombineTwoLinkedListValues (LinkedList l1, LinkedList l2) {
        int l1Sum = AddValues(l1.Head);
        int l2Sum = AddValues(l2.Head);

        return l1Sum + l2Sum;
    }

    private int AddValues (Node node) {
        if (node == null) {
            return 0;
        }
        return node.Data + AddValues(node.Next);
    }
}