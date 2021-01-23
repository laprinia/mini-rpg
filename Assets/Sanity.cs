using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    public int curSanity = 100;
    public int maxSanity = 100;

    public SanityBar healthBar;

    
    void Start()
    {
        curSanity = maxSanity;
    }

   
    public void AddSanity(int sanity)
    {
        curSanity += sanity;
        healthBar.SetHealth(curSanity);
    }
    public void RemoveSanity(int sanity)
    {
        curSanity -= sanity;
        healthBar.SetHealth(curSanity);
    }
}

