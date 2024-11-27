using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private Camera _camera => Camera.main;
    public GameObject _prefab;
    public Transform parent;
    public LayerMask _layerMask;
    public Vector3 offset;
    
    private float _distance = Mathf.Infinity;
    public int towerCost = 50;
    
    /// <summary>
    /// Attempts to place tower on mouse click.
    /// Tower will only be placed if the player clicks on a grid tile that isn't occupied and can afford the tower.
    /// </summary>
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit, _distance, _layerMask))
            return;

        if (!hit.transform.gameObject.TryGetComponent<GridTile>(out GridTile gridTile))
            return;

        if (GameManager.Instance.TryUseCash(towerCost) && gridTile.PlaceTower())
        {
            GameObject tower = GameObject.Instantiate(_prefab, hit.transform.position + offset, Quaternion.identity, parent);
        }
    }
}
