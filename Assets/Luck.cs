using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luck : MonoBehaviour
{
    public int curLuck = 0;
    public int maxLuck = 100;

    public LuckBar luckBar;

    
    void Start()
    {
        curLuck = maxLuck;
    }

   
    public void AddLuck(int luck)
    {
        curLuck += luck;
        luckBar.SetHealth(curLuck);
    }
}

