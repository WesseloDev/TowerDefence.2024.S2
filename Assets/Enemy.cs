using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public int cashOnDeath;
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.AddCash(cashOnDeath);
        }
    }

    public void DealDamage()
    {
        Destroy(gameObject);
        GameManager.Instance.TakeDamage(damage);
    }
}
