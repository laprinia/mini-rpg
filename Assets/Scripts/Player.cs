using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player: MonoBehaviour
{
    public int luck = 0;
    public int sanity = 100;
    public InventoryObject inventory;
    public NavMeshAgent agent;
    public Camera mainCamera;
    public Animator animator;
    private Vector3 previousPosition;
    public float curSpeed;
    float GetCurrentSpeed()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        return curSpeed;
    }

    private void Update()
    {
    
        animator.SetFloat("speed",GetCurrentSpeed());
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                animator.SetTrigger("isWalkingTrigger");
                agent.SetDestination(hit.point);
               
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
        
                var item = hit.transform.GetComponent<Item>();
                if (item)
                {
                    inventory.AddItem(item.itemObject, 1);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    public void IncreaseSanity(int amount)
    {
        Debug.Log("increased sanity by "+ amount);
        sanity += amount;
    }
    public void IncreaseLuck(int amount)
    {
        luck += amount;
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
