using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckBar : MonoBehaviour
{
    private Slider luckSlider;
    public Luck playerLuck;

    private void Start()
    {
        
        luckSlider = GetComponent<Slider>();
        luckSlider.maxValue = playerLuck.maxLuck;
        luckSlider.value = playerLuck.curLuck;
    }
    public void SetHealth(int hp)
    {
        luckSlider.value = hp;
    }
}
