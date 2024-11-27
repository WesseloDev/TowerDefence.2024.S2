using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private Camera _camera => Camera.main;
    [SerializeField] private GameObject _prefab;
    public Transform parent;

    public Vector3 offset;
    
    [SerializeField] private LayerMask _layerMask;
    private float _distance = Mathf.Infinity;

    public int cost = 50;
    
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

        if (GameManager.Instance.TryUseCash(cost) && gridTile.PlaceTower())
        {
            GameObject tower = GameObject.Instantiate(_prefab, hit.transform.position + offset, Quaternion.identity, parent);
        }
    }
}
