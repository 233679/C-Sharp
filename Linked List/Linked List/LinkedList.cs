using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    internal class LinkedList
    {
        /// <summary>
        /// The first node in the list.<br></br>
        /// This is always a dummy node with no content.
        /// </summary>
        private Node head;

        /// <summary>
        /// This will have the latest node.
        /// </summary>
        private Node current;

        /// <summary>
        /// The number of nodes in the list.
        /// </summary>
        private int Count;

        public LinkedList()
        {
            this.head = new Node();
            this.current = head;
        }

        public void AddAtLast(object data)
        {
            // Create a new node & assign the given data to it.
            Node newNode = new Node();
            newNode.Value = data;

            this.current.Next = newNode;
            this.current = newNode;

            // Update the count of nodes.
            this.Count++;
        }

        public void AddAtStart(object data)
        {
            // Create a new node.
            Node newNode = new Node() { Value = data };
            // Point it to the index 1.
            newNode.Next = this.head.Next;

            // Point the head to the new node.
            this.head.Next = newNode;
            this.Count++;
        }

        public void RemoveFromStart()
        {
            // Ensure that there is enough nodes to remove.
            if (this.head.Next == null)
            {
                return;
            }

            // Point to the node at index 1, the node at index 0 will be subject to the Gargabge Collector.
            this.head.Next = this.head.Next.Next;
            this.Count--;
        }

        public void RemoveFromEnd()
        {
            // Ensure that there is enough nodes to remove.
            if (this.head.Next == null)
            {
                return;
            }

            // Get the penultinate node.
            Node current = this.head;
            // Check if the node after this node has a null reference AKA if it is the last node.
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            // Remove the reference to the last node, subjecting it to the Garbage Collector.
            current.Next = null;

            // Decrement the count.
            this.Count--;
        }


        public override string ToString()
        {
            string buffer = "Head -> ";

            // Start at the head.
            Node current = head;
            // When next is null all nodes have been traversed.
            while (current.Next != null)
            {
                // Advance down list
                current = current.Next;
                buffer += $"{current.Value} -> ";
            }

            buffer += "END";
            return buffer;
        }
    }
}
