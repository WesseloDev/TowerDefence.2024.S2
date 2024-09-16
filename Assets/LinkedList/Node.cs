using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkedList
{
    public class Node
    {
        public string name;
        public int gangnamStyleCount = 0;

        public Node next;
        public Node prev;

        public Node(string name, int count)
        {
            this.name = name;
            gangnamStyleCount = count;
            next = null;
            prev = null;
        }
    }

}