using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : Dijkstras
{
    // Nodes in this implementation won't move.
    // If you want moving nodes, do this heuristic search at another point.
    protected override void Start()
    {
        foreach (Node nodeInScene in _nodesInScene)
        {
            nodeInScene.SetUpHeuristic(goalNode.transform.position);
        }

        base.Start();
    }

    protected override bool RunAlgorithm(Node start, Node goal)
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
            unexplored.Sort((a,b) => a.pathHeuristicWeight.CompareTo(b.pathHeuristicWeight));

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
