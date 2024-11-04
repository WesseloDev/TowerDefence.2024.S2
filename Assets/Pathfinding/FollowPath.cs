using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public AStar aStar;

    public Node startNode, goalNode;

    private List<Node> _path;
    
    void Start()
    {
        _path = aStar.FindShortestPath(startNode, goalNode);
        
        aStar.DebugPath(_path);
    }

    // Update is called once per frame
    void Update()
    {
        Node current = _path[0];
        int i = 0;
        while (current != null)
        {
            
        }
    }
}
