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
        linkedList.Push(new Node(15));
        linkedList.Push(new Node(10));
        linkedList.Push(new Node(7));
        linkedList.Push(new Node(5));
        linkedList.Push(new Node(2));

        LinkedList linkedList2 = new LinkedList();
        linkedList2.Push(new Node(9));
        linkedList2.Push(new Node(15));
        linkedList2.Push(new Node(10));
        linkedList2.Push(new Node(7));
        linkedList2.Push(new Node(5));
        linkedList2.Push(new Node(2));
        
        Console.WriteLine(CompareTwoListsLexicographically(linkedList, linkedList2));

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
}