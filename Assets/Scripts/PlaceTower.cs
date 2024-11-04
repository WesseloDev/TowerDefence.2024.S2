using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private Camera _camera => Camera.main;
    [SerializeField] private GameObject _prefab;

    [SerializeField] private LayerMask _layerMask;
    private int _towerLayer = 7;
    private float _distance = Mathf.Infinity;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit, _distance, _layerMask))
            return;

        Debug.Log(hit.transform.gameObject.layer);
        
        if (hit.transform.gameObject.layer == _towerLayer)
            return;

        GameObject tower = GameObject.Instantiate(_prefab, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
    }
}
