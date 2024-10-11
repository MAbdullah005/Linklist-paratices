using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Linklistapplication
{
    // 1 add fist
    // 2 add last 
    // 3 delete fist
    // 4 delete last
    // 5 contain
    // 6 index of
    // 7 size
    // 8 reverse
    // 9 find midle 
    // 10 addloop in linklist 
    // 11 find loop in linklist
    // 12 remove loop in link list (not tested)
    public class Linklist
    {
        public class Node
        {
            public int value;
            public Node? Next;
            public Node()
            {

            }
            public Node(int val)
            {
                this.value = val;
            }
        }
        private int size = 0;
        private Node Head;
        private Node Tail;
        public Linklist()
        {
            Head = null!;
            Tail = null!;
        }
        public void addfist(int value)
        {
            Node newnode = new Node(value);
            if (Head == null)
            {
                Tail = newnode;
            }
            newnode.Next = Head;
            Head = newnode;
            size++;
        }
        public void addlast(int value)
        {
            Node newnode = new Node(value);
            if (Head == null)
            {
                Tail = Head = newnode;
            }
            else
            {
                Tail.Next = newnode;
                Tail = newnode;
            }
            size++;
        }
        public void deletefist()
        {
            if (Head == null)
            {
                Console.WriteLine("linklist is empty");
                return;
            }
            else if (Head == Tail)
            {
                Head = Tail = null!;
                size--;
                return;
            }
            Node newnode = new Node();
            newnode = Head!.Next!;
            Head.Next = null;
            Head = newnode;
            size--;
        }
        public void deletelast()
        {
            if (Head == null)
            {
                Console.WriteLine("linklist is empty");
                return;
            }
            else if (Head == Tail)
            {
                Head = Tail = null!;
                size--;
                return;
            }
            Node newnode = new Node();
            Node previous = new Node();
            newnode = Head;
            while (newnode.Next != null)
            {
                previous = newnode;
                newnode = newnode.Next!;
            }
            Tail = previous!;
            Tail.Next = null!;
            size--;
        }
        public bool contain(int value)
        {
            return indexof(value) != -1;
        }
        public int indexof(int value)
        {
            int count = 0;
            var current = Head;
            while (current != null)
            {
                if (current.value == value) return count;
                current = current.Next;
                count++;
            }
            return -1;
        }
        public int Size()
        {
            return size;
        }
        public int[] toarray()
        {
            var current = Head;
            int index = 0;
            int[] array = new int[size];
            while (current != null)
            {
                array[index++] = current.value;
                current = current.Next!;
            }
            return array;
        }
        public void reverse()
        {
            var curent = Head;
            var previos = curent;
            curent = curent.Next;
            while (curent != null)
            {
                var n = curent.Next;
                curent.Next = previos;
                previos = curent;
                curent = n;
            }
            Tail = Head;
            Tail.Next = null;
            Head = previos;
        }
        public int get_Kehnodeformend(int k)
        {
            int count = 0;
            var previous = Head;
            var curent = Head;
            if (Head == null || (k - 1) < 0)
            {
                Console.WriteLine("no kth node from end ");
                return -1;
            }
            while (curent != null)
            {
                if (count <= (k - 1))
                {
                    curent = curent.Next;
                    if (curent == null)
                    {
                        Console.WriteLine("link list is not so large ");
                        return -1;
                    }
                    count++;
                }
                else
                {
                    curent = curent!.Next;
                    previous = previous.Next!;
                }
            }
            return previous.value;
        }
        public void print_midle()
        {
            var a = Head;
            var b = Head;
            if (Head == null)
            {
                throw new Exception("null link list");
            }
            while (b != Tail && b!.Next != Tail)
            {
                b = b.Next!.Next;
                a = a.Next!;
            }
            if (a != Tail)
            {
                Console.WriteLine("num even  middle value " + a.value + " , " + a.Next!.value);
            }
            else
            {
                Console.WriteLine("num even  middle value " + a.value);
            }
        }
        public void addloop(int a)
        {
            var current = Head;
            for (int count = 1; count <= a; count++)
            {
                current = current.Next!;
            }
            Tail.Next = current;
        }
        public Node hasloop()
        {
            var current = Head;
            var previos = Head;
            while (current != null && current.Next != null)
            {
                current = current.Next!.Next;
                previos = previos.Next!;
                if (previos == current)
                {
                    previos = Head;
                    while (current != null)
                    {
                        previos = previos.Next!;
                        current = current.Next!;
                        if (previos == current)
                        {
                            Console.WriteLine("loop in linkliast at point " + previos.value);
                            return previos;
                        }
                    }
                }
            }
            Console.WriteLine("no loop in linklist -1");
            return null!;
        }
        public void avoid_loop()
        {
            var point = hasloop();
            if (point != null)
            {
                var previous = point.Next;
                while (point != previous!.Next)
                {
                    previous = previous!.Next;
                }
                previous.Next = Tail.Next = null;
            }
        }
        public void avoid_any_loop()
        {
            avoid_loop();
            avoid_loop();
        }
        public void print()
        {
            Console.WriteLine("print");
            Node newnode = new Node();
            newnode = Head;
            while (newnode != null)
            {
                Console.WriteLine(newnode.value);
                newnode = newnode.Next!;
            }
        }
    }
    public class Program
    {
        static void Main()
        {

            Linklist linklist = new Linklist();
            for (int count = 1; count <= 10; count++)
            {
                linklist.addlast(count);
            }
            Console.WriteLine("contain " + linklist.contain(12));
            Console.WriteLine("size of link list" + linklist.Size());
            Console.WriteLine("index of " + linklist.indexof(12));
            linklist.reverse();
            linklist.print_midle();
            Console.WriteLine("kth node fom end " + linklist.get_Kehnodeformend(5));
            linklist.addloop(5);
            linklist.hasloop();
            linklist.avoid_loop();
            linklist.print();
        }
    }
}