using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIElements : MonoBehaviour
{
    private bool isInventoryShowing;
    public bool isSpiritShowing;
    public GameObject inventoryCanvas;
    public GameObject spiritCanvas;

    private void Start()
    {
        inventoryCanvas.SetActive(false);
        spiritCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryShowing = !isInventoryShowing;
            inventoryCanvas.SetActive(isInventoryShowing);

        }else if (Input.GetKeyDown(KeyCode.Z))
        {
            isSpiritShowing = !isSpiritShowing;
            spiritCanvas.SetActive(isSpiritShowing);
        }

    }
}
