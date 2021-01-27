using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBar : MonoBehaviour
{
    private Slider sanitySlider;
    public Spirit playerSanity;

    private void Start()
    {
        
        sanitySlider = GetComponent<Slider>();
        sanitySlider.maxValue = playerSanity.maxSpirit;
        sanitySlider.value = playerSanity.curSpirit;
    }
    public void SetHealth(int hp)
    {
        sanitySlider.value = hp;
    }
}
