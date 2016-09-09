// Created: Daniel Swain
// Date: 09/09/2016
//
// Custom object representing a single node in a doubly linked list.

namespace Doubly_Linked_List
{
    class Node
    {
        // Node properties
        public int key;
        public string data;
        Node prevNode;
        Node nextNode;

        // Constructor for constructing a node. Note, the node's prev and next node default to null and are
        // set in the insertion methods in List.cs.
        public Node(int nodeKey, string nodeData)
        {
            key = nodeKey;
            data = nodeData;
            prevNode = null;
            nextNode = null;
        }

        // Get the previous node in the list.
        public Node getPrev()
        {
            return prevNode;
        }

        // Get the next node in the list.
        public Node getNext()
        {
            return nextNode;
        }

        // Set the previous node for the node.
        public void setPrev(Node node)
        {
            prevNode = node;
        }

        // Set the next node for the node.
        public void setNext(Node node)
        {
            nextNode = node;
        }
    }
}
