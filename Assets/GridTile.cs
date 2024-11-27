using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public bool hasTower;

    public bool CanPlaceTower()
    {
        if (hasTower)
            return false;

        return true;
    }
}
