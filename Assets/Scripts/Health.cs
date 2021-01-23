using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 100;
    public int maxHealth = 100;

    public HealthBar healthBar;

    
    void Start()
    {
        curHealth = maxHealth;
    }

   
    public void AddHealth(int health)
    {
        curHealth += health;
        healthBar.SetHealth(curHealth);
    }
    public void RemoveHealth(int health)
    {
        curHealth -= health;
        healthBar.SetHealth(curHealth);
    }
}

