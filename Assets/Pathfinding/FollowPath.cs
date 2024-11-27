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

        StartCoroutine("StartMoving");
    }

    void OnDestroy()
    {
        Node.heuristicChanged -= UpdatePath;
    }

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

    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(1);

        _moving = true;
    }
    
    public void UpdatePath()
    {
        _path = _aStar.FindShortestPath(_current, Grid.Instance.EndNode);
        _index = 0;
        //_current = _path[_index];
    }
}
