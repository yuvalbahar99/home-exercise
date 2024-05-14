using System;
using System.Collections.Generic;

namespace oop
{
    internal class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public Node Maximum { get; set; }
        public Node Minimum { get; set; }

        public LinkedList(Node head)
        {
            Head = head;
            UpdateTailAndMaxMin();
        }

        public void UpdateTailAndMaxMin()
        {
            Node head_backup = Head;
            Maximum = Head;
            Minimum = Head;
            while (head_backup.Next != null)
            {
                head_backup = head_backup.Next;
                UpdateMaxMin(head_backup);
            }
            Tail = head_backup;
        }
        public void UpdateMaxMin(Node item)
        {
            if (item.Value > Maximum.Value)
                Maximum = item;
            if (item.Value < Minimum.Value)
                Minimum = item;
        }

        public void Appeand(int value)
        {
            Tail.Next = new Node(value, null);
            Tail = Tail.Next;
            UpdateMaxMin(Tail);
        }

        public void Prepend(int value)
        {
            Head = new Node(value, Head);
            UpdateMaxMin(Head);
        }

        public int Pop()
        {
            int returnValue = Tail.Value;
            if (Head == Tail)
                return returnValue;
            Node head_backup = Head;
            while (head_backup.Next != Tail)
                head_backup = head_backup.Next;
            head_backup.Next = null;
            UpdateTailAndMaxMin();
            return returnValue;

        }
        public int Unqueue()
        {
            int returnValue = Head.Value;
            Head = Head.Next;
            UpdateTailAndMaxMin();
            return returnValue;
        }

        public IEnumerable<int> ToList()
        {
            Node head_backup = Head;
            while (head_backup != null)
            {
                yield return head_backup.Value;
                head_backup = head_backup.Next;
            }
        }
        public List<int> ValuesList()
        {
            Node head_backup = Head;
            List<int> list = new List<int> { };
            while (head_backup != null)
            {
                list.Add(head_backup.Value);
                head_backup = head_backup.Next;
            }
            return list;
        }

        public bool IsCircular()
        {
            if (Tail.Next == Head)
                return true;
            return false;
        }
        public void Sort()
        {
            List<int> valuesList = this.ValuesList();
            valuesList.Sort();
            Head = new Node(valuesList[0], null);
            UpdateTailAndMaxMin();
            for (int i = 1; i < valuesList.Count; i++)
                this.Appeand(valuesList[i]);
        }
        public Node GetMaxNode()
        {
            return Minimum;
        }
        public Node GetMinNode()
        {
            return Maximum;
        }
    }
}
