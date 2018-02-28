using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList list = new LinkList();
            list.PrintAllNodes();
            Console.WriteLine();
            list.AddAtLast("value1");
            list.AddAtLast("value2");
            list.AddAtStart("start1");
            
            list.AddAtStart("start2");
            list.PrintAllNodes();
          //  list.RemoveAtStart();
            //list.PrintAllNodes();
            list.AddAtLast("value2_end");
            list.PrintAllNodes();
            list.RemoveNodeByValue(list.Head, "start2");
            list.PrintAllNodes();
            list.RemoveNodeByValue(list.Head, "value2_end");
            list.PrintAllNodes();
            Console.Read();
        }
    }

    public class Node
    {
        public Node Next;
        public object Value;
    }

    public class LinkList
    {
        public Node Head;
        private Node Current;
        public int Count;
        public LinkList()
        {
            Head = new Node();
            Current = Head;
        }

        public void AddAtLast(object data)
        {
            Node newnode = new Node();
            newnode.Value = data;
            Current.Next = newnode;
            Current = newnode;
            Count++;
        }

        public void AddAtStart(object data)
        {
            Node newnode = new Node { Value=data};
            newnode.Next = Head.Next;
            Head.Next = newnode;
            Count++;
        }
        public void RemoveAtStart()
        {
            if (Count > 0)
            {
                Head.Next = Head.Next.Next;
                Count--;
            }
            else
            {
                Console.WriteLine("no node available to delete");
            }
        }

        public void RemoveNodeByValue( Node head,object key)
        {
            Node temp = head;
            Node prev = null;
            //if (temp.Next != null && temp.Value == key)
            //{
            //    temp = temp.Next;
            //}
            while (temp != null && temp.Value != key)
            {
                prev = temp;
                temp = temp.Next;
            }
            if (temp.Next != null || temp.Value==key)
            {
                prev.Next = temp.Next;
                Count--;
            }
            else
            {
                Console.WriteLine("element not found");
            }

           
        }



        public void PrintAllNodes()
        {
            Console.Write("head->");
            Node cur = Head;
            while (cur.Next != null)
            {
                cur = cur.Next;
                Console.Write(cur.Value);
                Console.Write("->");
            }
            Console.Write("Null ");
            Console.WriteLine("count=" +Count);
            Console.WriteLine();
        }
    }


}
