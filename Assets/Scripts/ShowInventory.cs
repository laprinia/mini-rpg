using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    private bool isShowing;
    public GameObject canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            isShowing = !isShowing;
            canvas.SetActive(isShowing);

        }
        
    }
}
