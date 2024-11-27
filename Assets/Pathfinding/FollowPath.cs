using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : MonoBehaviour
{
    public AStar aStar;

    public Node startNode, goalNode;

    private List<Node> _path;
    private Node _current;
    private int _index = 0;

    void Start()
    {
        _path = aStar.FindShortestPath(startNode, goalNode);
        _current = _path[_index];

        aStar.DebugPath(_path);
    }

    void Update()
    {
        if (!Mathf.Approximately(_current.transform.position.magnitude - transform.position.magnitude, 0f))
        {
            transform.position = Vector3.MoveTowards(transform.position, _current.transform.position, 1f * Time.deltaTime);
        }
        else
        {
            if (_index == _path.Count - 1)
                return;

            _index++;
            _current = _path[_index];
        }
    }
}
