using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private string _enemyTag = "Enemy";

    private Collider _collider;

    private Enemy _tracked;
    private Vector3 _trackedPos => _tracked.transform.position;
    
    private LineRenderer _line;

    private Vector3 _offset = new Vector3(0, 0.55f, 0);

    public float damage;
    private bool _attacking = false;
    
    void Awake()
    {
        _collider = GetComponent<Collider>();
        _line = GetComponent<LineRenderer>();

        _line.SetPosition(0, transform.position + _offset);
    }

    void Update()
    {
        if (!GameManager.Instance.gameActive || !_tracked)
        {
            StopAttacking();
            return;
        }
        
        transform.LookAt(new Vector3(_trackedPos.x, 1f, _trackedPos.z));
        _line.SetPosition(1, _trackedPos);
        //_tracked.health -= damage * Time.deltaTime;
    }

    void TrackObject(Collider other)
    {
        /*if (_tracked)
            return;*/
        
        if (other.gameObject.tag != _enemyTag)
            return;

        _tracked = other.gameObject.GetComponent<Enemy>();

        StartAttacking();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        TrackObject(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_tracked)
            TrackObject(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != _tracked.gameObject)
            return;
        
        _tracked = null;
        transform.rotation = Quaternion.identity;
        StopAttacking();
    }

    private void StartAttacking()
    {
        if (_attacking)
            return;
        
        _attacking = true;
        StartCoroutine("Attack");
    }

    private void StopAttacking()
    {
        StopCoroutine("Attack");
        _attacking = false;
        _line.enabled = false;
    }
    
    private IEnumerator Attack()
    {
        while (_tracked)
        {
            _line.enabled = true;
            _tracked.health -= damage;
            
            yield return new WaitForSeconds(0.2f);

            _line.enabled = false;
            
            yield return new WaitForSeconds(0.8f);
        }
    }
}
