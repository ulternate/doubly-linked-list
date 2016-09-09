using System;
// Created: Daniel Swain
// Date: 09/09/2016
//
// Custom object representing the Double Linked List, storing the nodes
// and current data in the list.

namespace Doubly_Linked_List
{
    class List
    {
        // The list properties are only the first and last element's in the list.
        private static Node first;
        private static Node last;

        // Constructor for the doubly linked list.
        public List()
        {
            // An empty list will have it's first and last elements equal to null.
            first = null;
            last = null;
        }

        // Get the first node for the list.
        public Node getFirst()
        {
            return first;
        }

        // Get the last node for the list.
        public Node getLast()
        {
            return last;
        }

        // Set the first node for the list.
        public void setFirst(Node node)
        {
            first = node;
        }

        // Set the last node for the list.
        public void setLast(Node node)
        {
            last = node;
        }

        // Find and return the node with the given key. Note, this will return the first node with
        // the matching key if there are any duplicates.
        public Node findNode(List list, int searchKey)
        {
            // Temporary nodes used to find the node with the given key.
            Node foundNode = null;
            Node checkNode = list.getFirst();

            while (checkNode != null && checkNode.key != searchKey)
            {
                if (checkNode.getNext() == null)
                {
                    // No next item so return null as it wasn't found and has reached the end of list.
                    return null;
                }
                else
                {
                    // Update the checkNode we're checking to be the next node of the old checkNode
                    // and repeat this loop.
                    checkNode = checkNode.getNext();
                }
            }

            // Update the foundNode as we've finished the loop and have found it.
            foundNode = checkNode;

            return foundNode;
        }

        // Insert a new node after the desired node.
        public void insertAfterNode(List list, Node nodeBeingInserted, Node node)
        {
            // Set the prev and next node of the node being inserted.
            // This should set the previous to the old node, and the next
            // to the old node's next node.
            nodeBeingInserted.setPrev(node);
            nodeBeingInserted.setNext(node.getNext());

            // Check if the next node is null (i.e. it's the new last node in the list).
            if (node.getNext() == null)
            {
                // If it is then set the last node of the list to the one that was inserted.
                list.setLast(nodeBeingInserted);
            }
            else
            {
                // Otherwise the next node for the oldNode will need it's previous node's reference updated
                // to point to the nodeBeingInserted.
                node.getNext().setPrev(nodeBeingInserted);
            }

            // Update the next node of the old node to point to the nodeBeingInserted to complete the insertion.
            node.setNext(nodeBeingInserted);
        }

        // Insert a new node before a desired node.
        public void insertBeforeNode(List list, Node nodeBeingInserted, Node node)
        {
            // Set the prev and next nodes of the node being inserted.
            // This should set the previous to the previous of the old node, and the next
            // to the old node.
            nodeBeingInserted.setPrev(node.getPrev());
            nodeBeingInserted.setNext(node);

            // Check if the previous node is null (i.e. it's the new first node in the list).
            if (node.getPrev() == null)
            {
                list.setFirst(nodeBeingInserted);
            }
            else
            {
                // Otherwise the previous node for the oldNode will need it's next node's reference updated
                // to point to the nodeBeingInserted.
                node.getPrev().setNext(nodeBeingInserted);
            }

            // Update the previous node of the old node to point to the nodeBeingInserted to complete the insertion.
            node.setPrev(nodeBeingInserted);
        }

        // Insert the node at the begining of the list.
        public void insertAtBegining(List list, Node nodeBeingInserted)
        {
            // If the list doesn't have a first node then it can't have a last node so add the
            // node being inserted as the first and last nodes.
            if (list.getFirst() == null)
            {
                list.setFirst(nodeBeingInserted);
                list.setLast(nodeBeingInserted);
                // The nodeBeingInserted is the only node in the list so it has no next and prev nodes.
                nodeBeingInserted.setPrev(null);
                nodeBeingInserted.setNext(null);
            }
            else
            {
                // We use the insertBeforeNode method to insert before the old first node.
                insertBeforeNode(list, nodeBeingInserted, list.getFirst());
            }
        }

        // Insert the node at the end of the list.
        public void insertAtEnd(List list, Node nodeBeingInserted)
        {
            // If the list doesn't have a last node then it can't have a first node so add the
            // node being inserted as the first and last nodes.
            if (list.getLast() == null)
            {
                // Use the insertAtBegining function.
                insertAtBegining(list, nodeBeingInserted);
            }
            else
            {
                // We use the insertAfterNode method to insert after the old last node.
                insertAfterNode(list, nodeBeingInserted, list.getLast());
            }
        }

        // Remove a node from the list.
        public void deleteNode(List list, Node nodeBeingDeleted)
        {
            // If the previous node of the nodeBeingDeleted is null then we need
            // to update the first node of the list to be the next node from the nodeBeingDeleted.
            if (nodeBeingDeleted.getPrev() == null)
            {
                list.setFirst(nodeBeingDeleted.getNext());
            }
            else
            {
                // Otherwise set the previous node and set it's next node to point to the next node from the
                // nodeBeingDeleted.
                nodeBeingDeleted.getPrev().setNext(nodeBeingDeleted.getNext());
            }

            // If the next node of the nodeBeingDeleted is null then we need
            // to update the last node of the list to be the prev node from the nodeBeingDeleted.
            if (nodeBeingDeleted.getNext() == null)
            {
                list.setLast(nodeBeingDeleted.getPrev());
            }
            else
            {
                // Otherwise set the next node and set it's prev node to point to the prev node from the
                // nodeBeingDeleted.
                nodeBeingDeleted.getNext().setPrev(nodeBeingDeleted.getPrev());
            }
        }

        // Traverse and print the contents of the list either forward of backwards.
        public void traverseAndPrintList(List list, int traversalMethod)
        {
            switch (traversalMethod)
            {
                case 1:
                    Console.WriteLine("Traversing the list using the forwards traversal method.");
                    forwardTraversal(list);
                    break;

                case 2:
                    Console.WriteLine("Traversing the list using the backwards traversal method.");
                    backwardsTraversal(list);
                    break;

                default:
                    Console.WriteLine("Traversing the list using the forwards traversal method.");
                    forwardTraversal(list);
                    break;
            }
        }

        // Traverse the list from first to last.
        private void forwardTraversal(List list)
        {
            Node currentNode = list.getFirst();

            while (currentNode != null)
            {
                // Print the node to the console and then get the next node.
                Console.Write("[{0}, \"{1}\"] ", currentNode.key, currentNode.data);
                currentNode = currentNode.getNext();
            }
        }

        // Traverse the list from last to first.
        private void backwardsTraversal(List list)
        {
            Node currentNode = list.getLast();

            while (currentNode != null)
            {
                // Print the node to the console then get the previous node.
                Console.Write("[{0}, \"{1}\"] ", currentNode.key, currentNode.data);
                currentNode = currentNode.getPrev();
            }
        }
    }
}
