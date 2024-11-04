using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private string _enemyTag = "Enemy";

    private Collider _collider;

    [SerializeField] private GameObject _trackedObject;
    private Vector3 _trackedPos => _trackedObject.transform.position;
    
    private LineRenderer _line;

    private Vector3 _offset = new Vector3(0, 0.55f, 0);
    
    void Awake()
    {
        _collider = GetComponent<Collider>();
        _line = GetComponent<LineRenderer>();

        _line.SetPosition(0, transform.position + _offset);
    }

    void Update()
    {
        if (!_trackedObject)
            return;
        
        transform.LookAt(new Vector3(_trackedPos.x, 1f, _trackedPos.z));
        _line.SetPosition(1, _trackedPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi");
        if (other.gameObject.tag != _enemyTag)
            return;

        _trackedObject = other.gameObject;
        _line.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _trackedObject)
        {
            _trackedObject = null;
            transform.rotation = Quaternion.identity;
            _line.enabled = false;
        }
    }
}
