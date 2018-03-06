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
            LinkList l = new LinkList();
            l.AddAtLast(7); l.AddAtLast(10); l.AddAtLast(25); l.AddAtLast(35); l.AddAtLast(115); l.AddAtLast(117); l.AddAtLast(119);

            LinkList r = new LinkList();
            r.AddAtLast(3);r.AddAtLast(9); r.AddAtLast(10); r.AddAtLast(12); r.AddAtLast(100); r.AddAtLast(116);

            LinkList f= LinkList.SortMerge(l, r);
            f.PrintAllNodes();



            //  LinkList list = new LinkList();
            //  list.PrintAllNodes();
            //  Console.WriteLine();
            //  list.AddAtLast("value1");
            //  list.AddAtLast("value2");
            // // list.AddAtStart("start1");

            //  list.AddAtStart("start2");
            //  list.PrintAllNodes();
            ////  list.RemoveAtStart();
            //  //list.PrintAllNodes();
            //  list.AddAtLast("value2_end");
            //  list.PrintAllNodes();
            //  list.RemoveNodeByValue(list.Head, "start2");
            //  list.PrintAllNodes();
            //  list.RemoveNodeByValue(list.Head, "value2_end");
            //  list.PrintAllNodes();
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
            int cnt = 0;
            while (cur.Next != null)
            {
                cur = cur.Next;
                Console.Write(cur.Value);
                Console.Write("->");
                cnt++;
            }
            Console.Write("Null ");
            Console.WriteLine("count=" +cnt);
            Console.WriteLine();
        }

        public static LinkList SortMerge(LinkList a, LinkList b)
        {
            LinkList f = new LinkList();
            int firstListLength = a.Count;
            int secondListLength = b.Count;
            int j=0;
            int k = 0;
           // a.Current.Next = a.Head.Next;
            //b.Current.Next = b.Head.Next;
            while (firstListLength>j && secondListLength>k)
            {
               if((int)a.Head.Next.Value<=(int)b.Head.Next.Value)
                {
                    f.AddAtLast((int)a.Head.Next.Value);
                    j++;
                    a.Head.Next = a.Head.Next.Next;
                }
               else
                {
                    f.AddAtLast((int)b.Head.Next.Value);
                    k++;
                    b.Head.Next = b.Head.Next.Next;
                }
            }
            if(firstListLength==j)
            {
                f.Current.Next = b.Head.Next;
            }
            else if(secondListLength==k)
            {
                f.Current.Next = a.Head.Next;
            }
            return f;
        }
    }


}
