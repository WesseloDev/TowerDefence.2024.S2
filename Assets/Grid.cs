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

    public Node StartNode
    {
        get => _nodes[0];
    }
    public Node EndNode
    {
        get => _nodes[_nodes.Count - 1];
    }

    void Start()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                GameObject tile = Instantiate(prefab, new Vector3(offset * i, 0, offset * j), Quaternion.identity, parent);
                tile.name = _nodes.Count.ToString();

                Node node = tile.GetComponent<Node>();


                _nodes.Add(node);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
