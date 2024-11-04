using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Node graph, in scene
// Weighted queue
public class Node : MonoBehaviour
{
    public List<Node> Neighbours;

    private float _pathWeight = float.PositiveInfinity;
    public float PathWeight
    {
        get => _pathWeight;
        set => _pathWeight = value;
    }
    
    public int count { get; private set; }
    
    private Node _previousNode = null;

    public Node PreviousNode
    {
        get => _previousNode;
        set => _previousNode = value;
    }

    private float _heuristic;

    public float Heuristic
    {
        get => _heuristic;
        set => _heuristic = value;
    }

    public float pathHeuristicWeight => _pathWeight + _heuristic;
    
    public void ResetNode()
    {
        _pathWeight = float.PositiveInfinity;
        _previousNode = null;
    }

    private void OnValidate() => ValidateNeighbours();

    private void ValidateNeighbours()
    {
        foreach (var node in Neighbours)
        {
            if (node == null)
                continue;
            
            if (!node.Neighbours.Contains(this))
                node.Neighbours.Add(this);
        }
    }

    private void OnDrawGizmos()
    {
        if (Neighbours == null)
            return;

        float radius = 0.2f;
        
        Gizmos.color = Color.blue;

        foreach (var node in Neighbours)
        {
            if (node == null)
                return;

            Vector3 direction = node.transform.position - transform.position;
            Vector3 right = Vector3.Cross(direction, Vector3.up).normalized * 0.03f;
            Gizmos.DrawLine(transform.position + right, node.transform.position + right);
        }
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
    
    private void OnDestroy()
    {
        foreach (var node in Neighbours)
        {
            if (node == this)
                node.Neighbours.Remove(this);
        }
    }

    public float SetUpHeuristic(Vector3 goal)
    {
        _heuristic = Vector3.Distance(transform.position, goal);
        return _heuristic;
    }
}
