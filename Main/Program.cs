using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Main
{
    public static class MainClass
    {
        public static Node my_linklist = new Node();
        public static void Main(string[] arrgs)
        {
            LinkedList<int> linklist = new LinkedList<int>();
            linklist.AddFirst(new LinkedListNode<int>(17));
            linklist.AddLast(new LinkedListNode<int>(2));


            my_linklist.AddToHead(1);
            my_linklist.AddToHead(17);

            my_linklist.AddToPosition(0, new Node(99));
            my_linklist.AddToTail(new Node(89));



            Console.WriteLine();

            //my_linklist.RemoveHead();
            //my_linklist.PintMyNodes();
            //Console.WriteLine();
            //my_linklist.RemoveAtPosition(2);
            //my_linklist.PintMyNodes();
            //my_linklist.MakeCircular();

            //Console.WriteLine($"{my_linklist.IsCircular()}");
            //my_linklist.PintMyNodes();

            ListNode[] input = {
                new ListNode(1){next = new ListNode(4){next = new ListNode(5)}},
                new ListNode(1){next = new ListNode(3){next = new ListNode(4)}},
                new ListNode(2){next = new ListNode(6)}
                };

            ListNode mergerKList = MergeKLists(input);



            Console.Read();
        }

        #region LinkList
        #region Library
        public static LinkedList<int> AddInTail(this LinkedList<int> my_linklist, LinkedListNode<int> new_node)
        {
            my_linklist.AddLast(new_node);
            return my_linklist;
        }
        public static LinkedList<int> AddToHead(this LinkedList<int> my_linklist, LinkedListNode<int> new_node)
        {
            my_linklist.AddLast(new_node);
            return my_linklist;
        }
        #endregion

        #region Manual
        public class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }

            public Node()
            {

            }
            public Node(object data)
            {
                this.Data = data;
                this.Next = null;
            }
        }
        public static void PintMyNodes(this Node mynode)
        {
            while (mynode != null)
            {
                Console.Write(mynode.Data);
                if (mynode.Next != null)
                    Console.Write(" -> ");
                mynode = mynode.Next;
                Thread.Sleep(1000);
            }
            Console.WriteLine();

        }
        public static int NodeCount(this Node mynode)
        {
            int my_node_count = 0;
            while (mynode != null)
            {
                my_node_count++;
                mynode = mynode.Next;
            };
            return my_node_count;
        }
        public static void AddToHead(this Node parent_node, object new_data)
        {
            if (parent_node.Data == null)
            {
                my_linklist = new Node()
                { Data = new_data, Next = null };
                return;
            }

            Node new_node = new Node()
            {
                Next = parent_node,
                Data = new_data
            };
            my_linklist = new_node;
        }
        public static void AddToTail(this Node mynode, Node new_node)
        {
            while (mynode.Next != null)
                mynode = mynode.Next;
            mynode.Next = new_node;
        }
        public static void AddToPosition(this Node my_node, int position, Node new_node)
        {
            Node parent = my_node;
            Node current = my_node;
            int counter = 0;

            if (position < 0 || position > my_node.NodeCount())
            {
                my_linklist = my_node;
                return;
            }


            if (position == 0)
            {
                AddToHead(my_node, new_node.Data);
                return;
            }

            if (position + 1 == my_node.NodeCount())
            {
                my_node.AddToTail(new_node);
                return;
            }

            while (position - 1 != counter++)
            {
                parent = current;
                current = parent.Next;
            }
            new_node.Next = current;
            parent.Next = new_node;

        }
        public static void RemoveHead(this Node mynode)
        {
            my_linklist = mynode.Next;
        }
        public static void RemoveAtPosition(this Node mynode, int position)
        {
            Node current = mynode;
            int counter = 0;

            while (position - 1 != counter++)
                current = current.Next;

            if (current.Next == null)
                return;
            else if (current.Next.Next == null)
                current.Next = null;
            else
                current.Next = current.Next.Next;

        }
        public static bool IsCircular(this Node mynode)
        {
            Node fast = mynode.Next.Next;
            Node slow = mynode;

            while (fast != null || slow != null)
            {
                if (fast == slow)
                    return true;
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return false;
        }
        public static void MakeCircular(this Node mynode)
        {
            Node head = mynode;

            while (head.Next != null)
                head = head.Next;

            head.Next = mynode;
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode my_node = lists[0];
            foreach (ListNode node in lists.Skip(1))
            {
                if (my_node == null)
                {
                    my_node.val = node.val;
                    continue;
                }
                else
                {
                    ListNode current = node;
                    while (current.next != null)
                    {
                        if (current.val > node.val)
                        {
                            ListNode new_node = new ListNode(node.val);
                            new_node.next = current;
                            current = new_node;
                        }
                        current = current.next;
                    }
                    my_node = current;
                }
            }
            return my_node;
            #endregion
            #endregion
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}