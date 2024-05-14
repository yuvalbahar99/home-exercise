using System;
using System.Collections.Generic;

namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList(new Node(5, null));
            list.Prepend(2);
            list.Appeand(3);
            list.Appeand(7);
            list.Unqueue();
            list.Appeand(1);
            list.Prepend(6);
            list.Prepend(8);
            Console.WriteLine($"Out: {list.Pop()}");
            Console.WriteLine($"Min: {list.GetMinNode().Value}");
            Console.WriteLine($"Max: {list.GetMaxNode().Value}");
            IEnumerator<int> listIEnumerator = list.ToList().GetEnumerator();
            while (listIEnumerator.MoveNext())
                Console.WriteLine($"Item: {listIEnumerator.Current}");
            list.Sort();
            list.Tail.Next = list.Head;
            Console.WriteLine(list.IsCircular());

            NumericalExpression number = new NumericalExpression(23);
            Console.WriteLine(number.ToString());
            Console.WriteLine(NumericalExpression.SumLetters(23));
        }
    }
}
