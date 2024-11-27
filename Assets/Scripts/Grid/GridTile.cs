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

    /// <summary>
    /// Attempts to place a tower on the tile.
    /// </summary>
    /// <returns>false if cannot place tower, true if tower placed successfully</returns>
    public bool PlaceTower()
    {
        if (blocked)
            return false;

        SetHeuristic();
        Block();

        return true;
    }
    
    /// <summary>
    /// Sets heuristic of node, so AI avoids it.
    /// </summary>
    public void SetHeuristic()
    {
        _node.Heuristic = 999999999999999f;
    }

    /// <summary>
    /// Prevents towers being placed on the tile, and sets heuristics of the neighbours so AI will avoid them.
    /// </summary>
    public void Block()
    {
        _renderer.material.color = Color.black;
        blocked = true;
        
        foreach (GridTile tile in neighbours)
            tile.SetHeuristic();
    }
}
