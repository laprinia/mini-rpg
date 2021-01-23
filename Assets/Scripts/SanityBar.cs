using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    private Slider sanitySlider;
    public Sanity playerSanity;

    private void Start()
    {
        
        sanitySlider = GetComponent<Slider>();
        sanitySlider.maxValue = playerSanity.maxSanity;
        sanitySlider.value = playerSanity.maxSanity;
    }
    public void SetHealth(int hp)
    {
        sanitySlider.value = hp;
    }
}
