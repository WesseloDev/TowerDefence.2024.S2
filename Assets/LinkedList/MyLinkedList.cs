using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkedList
{
    public class MyLinkedList : MonoBehaviour
    {
        void Start()
        {
            Node Andrew = new Node("Andrew", 100);
            Node Shoji = new Node("Shoji", 30);
            Node brainDead = new Node("Brain Dead", 90000);

            LinkedList linkedList = new LinkedList(Andrew);
            linkedList.InsertNext(Shoji);

            linkedList.PrintAll();
            
            linkedList.PrintCurrent(); // Andrew
            linkedList.Next();
            linkedList.Next();
            linkedList.InsertNext(brainDead);
            linkedList.PrintCurrent(); // Shoji
            linkedList.Next();
            linkedList.PrintCurrent(); // brainDead
        }
    }
}