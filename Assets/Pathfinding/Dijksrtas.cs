using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dijksrtas : MonoBehaviour
{
    public Node startNode, endNode;

    protected Node[] _nodesInScene;

    protected void GetAllNodes()
    {
        _nodesInScene = FindObjectsOfType<Node>();
    }

    void Awake()
    {
        GetAllNodes();
    }

    protected virtual bool RunAlgorithm(Node start, Node goal)
    {
        List<Node> unexplored = new List<Node>();

        Node startNode = null;
        Node goalNode = null;

        foreach (Node nodeInScene in _nodesInScene)
        {
            nodeInScene.ResetNode();
            unexplored.Add(nodeInScene);

            if (start == nodeInScene)
            {
                startNode = nodeInScene;
            }

            if (goal == nodeInScene)
            {
                goalNode = nodeInScene;
            }
        }

        // Make sure nodes actually exist
        if (startNode == null || goalNode == null)
            return false;

        startNode.PathWeight = 0;

        while (unexplored.Count > 0)
        {
            // Compare node by weight
            unexplored.Sort((a,b) => a.PathWeight.CompareTo(b.PathWeight));

            // Pop first node
            Node current = unexplored[0];
            unexplored.RemoveAt(0);

            foreach (Node neighbourNode in current.Neighbours)
            {
                if (!unexplored.Contains(neighbourNode))
                    continue;

                // THIS IS A LOT OF SQUARE ROOTING
                float neighbourWeight = Vector3.Distance(current.transform.position, neighbourNode.transform.position);

                neighbourWeight += current.PathWeight;

                if (neighbourWeight < neighbourNode.PathWeight)
                {
                    neighbourNode.PathWeight = neighbourWeight;
                    neighbourNode.PreviousNode = current;
                }
                
            }

            if (current == goalNode)
                return true;
        }
        
        return false;
    }
}
