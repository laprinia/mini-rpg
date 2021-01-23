using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthSlider;
    public Health enemyHealth;

    private void Start()
    {
        
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = enemyHealth.maxHealth;
        healthSlider.value = enemyHealth.curHealth;
      
    }

    private void Update()
    {
        transform.position = Input.mousePosition + new Vector3(0, 2, 0);
    }

    public void SetHealth(int hp)
    {
        healthSlider.value = hp;
    }
}