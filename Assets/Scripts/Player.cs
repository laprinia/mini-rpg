using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class Player: MonoBehaviour
{
    public GameObject shuriken;
    public GameObject katana;
    public int luck = 0;
    public int sanity = 100;
    public InventoryObject inventory;
    public NavMeshAgent agent;
    public Camera mainCamera;
    public Animator animator;
    private Vector3 previousPosition;
    private bool isRanged;
    private float curSpeed;

    private void Start()
    {
        inventory.AddItem(katana.GetComponent<Item>().itemObject,1);
        inventory.AddItem(shuriken.GetComponent<Item>().itemObject,1);
    }

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
            if(EventSystem.current.IsPointerOverGameObject()) return;
            
            Ray ray=mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
               
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               
                if(hit.transform.tag.Equals("Enemy"))
                {
                    AttackEnemy(hit);
                }
                var item = hit.transform.GetComponent<Item>();
                if (item)
                {
                    inventory.AddItem(item.itemObject, 1);
                    Destroy(hit.transform.gameObject);
                }
                
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            isRanged = !isRanged;
            katana.gameObject.SetActive(!isRanged);
            shuriken.gameObject.SetActive(isRanged);
        }
    }

    public void AttackEnemy(RaycastHit hit)
    {
        if (isRanged)
        {
            agent.SetDestination(hit.point);
            StartCoroutine(WaitToArriveCoroutine("isThrowingTrigger",true));
        }
        else
        {
             
            agent.SetDestination(hit.point);
            StartCoroutine(WaitToArriveCoroutine("isSlashingTrigger",false));

        }
        //todo take damage
        //hit.collider.gameObject
    }

    IEnumerator WaitToArriveCoroutine(String trigger,bool isRanged)
    {
        while (agent.pathPending)
        {
            
            yield return null;
        }

        while (agent.remainingDistance >= agent.stoppingDistance+(isRanged?6f:0f))
        {
            
            yield return null;
        }

        if (isRanged)
        {
            agent.isStopped = true;
        }
        while (agent.velocity.sqrMagnitude != 0)
        {
            
            yield return null;
        }
        
        animator.SetTrigger(trigger);
        
    }
    public void IncreaseSanity(int amount)
    {
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