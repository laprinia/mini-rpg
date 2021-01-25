using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour,Entity
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void TakeDamage(int amount)
    {
        health.RemoveHealth(amount);
        if (health.curHealth <= 0)
        {
            StartCoroutine(Die());
           
        }
    }

    public bool isStatic()
    {
        return true;
    }

    private void OnMouseOver()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private IEnumerator Die()
    {
        
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }

}
