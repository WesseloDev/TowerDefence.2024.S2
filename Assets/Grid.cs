using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public int xSize, ySize;
    public float offset;

    private List<Node> _nodes = new List<Node>();
    private List<GridTile> _tiles = new List<GridTile>();
    
    public Node StartNode
    {
        get => _nodes[0];
    }
    public Node EndNode
    {
        get => _nodes[_nodes.Count - 1];
    }

    private static Grid _instance;

    public static Grid Instance
    {
        get => _instance;
        set
        {
            if (_instance)
            {
                Debug.Log("Multiple instances of Grid in scene.");
                Destroy(value);
                return;
            }

            _instance = value;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    
    void Start()
    {
        GenerateGrid();
        ConnectGridNeighbours();

        /*AStar.Instance.startNode = _nodes[0];
        AStar.Instance.goalNode = _nodes[_nodes.Count - 1];
        AStar.Instance.UpdateHeuristics();*/
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                GameObject tile = Instantiate(prefab, new Vector3(offset * i, 0, offset * j), Quaternion.identity, parent);
                tile.GetComponent<MeshRenderer>().material.color = _nodes.Count % 2 == 0 ? Color.gray : Color.white;
                tile.name = _nodes.Count.ToString();

                Node node = tile.GetComponent<Node>();
                _nodes.Add(node);
                
                GridTile gridTile = tile.GetComponent<GridTile>();
                _tiles.Add(gridTile);
                if ((_nodes.Count != 1 || _nodes.Count != xSize * ySize) && Random.Range(1,10) == 1)
                {
                    gridTile.SetHeuristic();
                    gridTile.Block();
                }
            }
        }
    }

    // Below function only works properly for grids that have the same x and y size (i.e. 4x4, 9x9, 24x4)
    private void ConnectGridNeighbours()
    {
        int index = 0;
        foreach (Node node in _nodes)
        {
            int upIndex = index + xSize;
            int downIndex = index - xSize;
            int leftIndex = index - 1;
            int rightIndex = index + 1;
            
            if (upIndex > -1 && upIndex < _nodes.Count)
            {
                node.Neighbours.Add(_nodes[upIndex]);
                _tiles[index].neighbours.Add(_tiles[upIndex]);
            }
            if (downIndex > -1 && downIndex < _nodes.Count)
            {
                node.Neighbours.Add(_nodes[downIndex]);
                _tiles[index].neighbours.Add(_tiles[downIndex]);
            }
            if (leftIndex > -1 && leftIndex < _nodes.Count && index % xSize != 0)
            {
                node.Neighbours.Add(_nodes[leftIndex]);
                _tiles[index].neighbours.Add(_tiles[leftIndex]);
            }
            if (rightIndex > -1 && rightIndex < _nodes.Count && (index + 1) % xSize != 0)
            {
                node.Neighbours.Add(_nodes[rightIndex]);
                _tiles[index].neighbours.Add(_tiles[rightIndex]);
            }
            
            index++;

            node.SetUpHeuristic(EndNode.transform.position);
        }
    }
}
