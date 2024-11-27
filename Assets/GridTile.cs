using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public List<GridTile> neighbours;
    
    private Node _node;
    private MeshRenderer _renderer;
    
    public bool blocked = false;

    void Awake()
    {
        _node = GetComponent<Node>();
        _renderer = GetComponent<MeshRenderer>();
    }

    public bool PlaceTower()
    {
        if (blocked)
            return false;

        SetHeuristic();
        Block();

        return true;
    }
    
    public void SetHeuristic()
    {
        _node.Heuristic = 999999999999999f;
    }

    public void Block()
    {
        _renderer.material.color = Color.black;
        blocked = true;
        
        foreach (GridTile tile in neighbours)
            tile.SetHeuristic();
    }
}
