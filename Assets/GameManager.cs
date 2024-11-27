using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get => _instance;
        set
        {
            if (_instance)
            {
                Debug.LogWarning("More than one Game Manager. Remove second instance.");
                Destroy(value);
                return;
            }

            _instance = value;
        }
    }

    private float maxHealth = 100;
    public float health = 100;
    public int cash = 100;

    public static Action<int> cashChanged;
    public static Action<float> healthChanged;
    public static Action gameOver;
    
    public bool gameActive = true;
    
    void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthChanged?.Invoke(health / maxHealth);

        if (health <= 0)
        {
            gameActive = false;
            gameOver?.Invoke();
        }
    }

    public void AddCash(int amount)
    {
        cash += amount;
        cashChanged?.Invoke(cash);
    }
    
    public bool TryUseCash(int amount)
    {
        if (cash - amount >= 0)
        {
            cash -= amount;
            cashChanged?.Invoke(cash);
            return true;
        }

        return false;
    }
}
