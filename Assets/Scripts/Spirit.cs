using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public int curSpirit = 0;
    public int maxSpirit = 100;

    public SpiritBar spiritBar;

    
    void Start()
    {
        curSpirit = 0;
    }

   
    public void AddSpirit(int spirit)
    {
        curSpirit += spirit;
        spiritBar.SetHealth(curSpirit);
    }
}

