using System;

namespace oop
{
    internal class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
    }
}
