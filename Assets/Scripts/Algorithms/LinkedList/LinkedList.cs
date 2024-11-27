using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkedList
{
    public class LinkedList
    {
        public Node header; // first node in list
        public Node current; // current node we are looking at

        public LinkedList(){}
        public LinkedList(Node node)
        {
            header = node;
            header.next = null;
            header.prev = null;
            current = node;
        }

        public void InsertNext(Node newNode)
        {
            if (current.next == null)
            {
                newNode.prev = current;
                newNode.next = null;
                current.next = newNode;
            }
            else
            {
                current.next.prev = newNode;
                newNode.next = current.next;

                newNode.prev = current;
                current.next = newNode;
            }
        }
        
        public void DeleteNext()
        {
            if (current.next == null)
                return;

            Node delNode = current.next;
            current.next = current.next.next;
            current.next.prev = current;
            delNode = null;
        }

        public void Next()
        {
            if (current.next != null)
            {
                current = current.next;
            }
        }

        public void Prev()
        {
            if (current.prev != null)
            {
                current = current.prev;
            }
        }

        public void PrintCurrent()
        {
            Debug.Log(current.name + ", " + current.gangnamStyleCount);
        }

        public void Restart()
        {
            current = header;
        }
        
        public void PrintAll()
        {
            if (header == null)
                return;
            
            Node currentPrint = header;

            do
            {
                Debug.Log(currentPrint.name + ", " + currentPrint.gangnamStyleCount);
                currentPrint = currentPrint.next;
            } while (currentPrint != null);
        }
    }
}