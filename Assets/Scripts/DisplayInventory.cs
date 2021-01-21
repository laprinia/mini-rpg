using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    private const int MAX_COUNT = 12;
    public InventoryObject inventory;
    public float xStart=208.7f;
    public float yStart=417.6f;
    public int xOffset;

    public int noColumns;

    public int yOffset;
    Dictionary<InventorySlot,GameObject> itemDisplayed=new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }
    
    void CreateDisplay()
    {
        for (int i= 0; i < inventory.Container.Count; i++)
        {
            AddToItemsDisplayed(i);
        }
    }

    private void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                AddToItemsDisplayed(i);
            }
        }
    }

    void AddToItemsDisplayed(int indexInInventory)
    {
        int i = indexInInventory;
        var obj = Instantiate(inventory.Container[i].item.prefab,Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.GetComponent<RectTransform>().transform.position = Vector3.zero;
        obj.GetComponent<RectTransform>().transform.localPosition =GetPosition(i);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        itemDisplayed.Add(inventory.Container[i],obj);
    }
    
    Vector3 GetPosition(int i)
    {
        return new Vector3(xStart+(xOffset * (i % noColumns)), yStart+(-yOffset * (i / noColumns)),0f);
    }
}
