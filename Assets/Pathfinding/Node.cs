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

    public void ResetNode()
    {
        _pathWeight = float.PositiveInfinity;
        _previousNode = null;
    }
}
