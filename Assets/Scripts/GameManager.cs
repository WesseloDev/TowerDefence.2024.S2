using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
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

    void Awake()
    {
        Instance = this;
    }
    
    #endregion
    
    private float maxHealth = 100;
    public float health = 100;
    public int cash = 100;

    public static Action<int> cashChanged;
    public static Action<float> healthChanged;
    public static Action gameOver;
    
    public bool gameActive = true;

    /// <summary>
    /// Take damage. If health is less than or equal to 0 after taking damage, game ends.
    /// </summary>
    /// <param name="amount">Amount of damage to take</param>
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

    /// <summary>
    /// Add cash.
    /// </summary>
    /// <param name="amount">Amount to add</param>
    public void AddCash(int amount)
    {
        cash += amount;
        cashChanged?.Invoke(cash);
    }
    
    /// <summary>
    /// Try to use cash.
    /// </summary>
    /// <param name="amount">How much cash you want to use</param>
    /// <returns>true if purchase is successful, false if not</returns>
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
