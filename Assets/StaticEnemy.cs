using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    private Health health;
    public void TakeDamage(int amount)
    {
        health.RemoveHealth(amount);
        if (health.maxHealth <= 0)
        {
            StartCoroutine(Die());
        }
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
