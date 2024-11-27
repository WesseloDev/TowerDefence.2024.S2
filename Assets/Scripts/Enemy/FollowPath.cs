using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private AStar _aStar;
    private List<Node> _path;
    private Node _current;
    private int _index = 0;

    private bool _moving = false;

    private Enemy _enemy;

    void Awake()
    {
        _aStar = GetComponent<AStar>();
        _enemy = GetComponent<Enemy>();
        
        Node.heuristicChanged += UpdatePath;
    }
    
    void Start()
    {
        _path = _aStar.FindShortestPath(Grid.Instance.StartNode, Grid.Instance.EndNode);
        _current = _path[_index];

        _moving = true;
    }

    void OnDestroy()
    {
        Node.heuristicChanged -= UpdatePath;
    }

    /// <summary>
    /// If not at the current target node, move towards it.
    /// If at the current target node and the current target node is the goal, deal damage to the player.
    /// If the current target node isn't the goal, start moving towards the next node in the path.
    /// </summary>
    void Update()
    {
        if (!GameManager.Instance.gameActive || !_moving)
            return;

        if (!Mathf.Approximately(_current.transform.position.magnitude - transform.position.magnitude, 0f))
        {
            transform.position = Vector3.MoveTowards(transform.position, _current.transform.position, _enemy.speed * Time.deltaTime);
        }
        else
        {
            if (_index == _path.Count - 1)
            {
                _moving = false;
                _enemy.DealDamage();
                return;
            }

            _index++;
            _current = _path[_index];
        }
    }

    /// <summary>
    /// When a node has it's heuristics changed, the AI recalculates its path.
    /// </summary>
    public void UpdatePath()
    {
        _path = _aStar.FindShortestPath(_current, Grid.Instance.EndNode);
        _index = 0;
    }
}
