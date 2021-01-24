using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class Player: MonoBehaviour
{
    public float attackCoolDown=2f;
    public GameObject shuriken;
    public GameObject katana;
    public int luck = 0;
    public int sanity = 100;
    public InventoryObject inventory;
    public NavMeshAgent agent;
    public Camera mainCamera;
    public Animator animator;
    private Vector3 previousPosition;
    private bool isAttacking;
    private bool isRanged;
    private float curSpeed;
    private WeaponObject shurikenWeaponObject;
    private WeaponObject katanaWeaponObject;
    private float attackTimeStamp = 0f;
 
    private void Awake()
    {
        inventory.AddItem(katana.GetComponent<Item>().itemObject,1);
        katanaWeaponObject = katana.GetComponent<Item>().itemObject as WeaponObject;
        inventory.AddItem(shuriken.GetComponent<Item>().itemObject,1);
        shurikenWeaponObject=shuriken.GetComponent<Item>().itemObject as WeaponObject;
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
        else if (Input.GetKeyDown(KeyCode.X)&& !isAttacking)
        {
            isRanged = !isRanged;
            katana.gameObject.SetActive(!isRanged);
            shuriken.gameObject.SetActive(isRanged);
        }
    }

    public void AttackEnemy(RaycastHit hit)
    {
        
        int damageAmount;
        Entity entity = hit.collider.gameObject.GetComponent<Entity>();
        Health entityHealth=hit.collider.gameObject.GetComponent<Health>();
        isAttacking = true;
        if (isRanged)
        {

            damageAmount = shurikenWeaponObject.damage;
            agent.SetDestination(hit.point);
            StartCoroutine(GoAndAttackCoroutine("isThrowing",true,entity,entityHealth,damageAmount));
        }
        else
        {
            damageAmount = katanaWeaponObject.damage;
            agent.SetDestination(hit.point);
            StartCoroutine(GoAndAttackCoroutine("isSlashing",false,entity,entityHealth,damageAmount));

        }
        
    }

    IEnumerator GoAndAttackCoroutine(String animatorBool,bool isRanged,Entity entity, Health entityHealth, int damageAmount)
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
        animator.SetBool(animatorBool,true);
        while (entityHealth.curHealth>0)
        {
            if (Time.time >= attackTimeStamp)
            {
                attackTimeStamp = Time.time + attackCoolDown;
                entity.TakeDamage(damageAmount);
                
            }
            yield return null;
        }

        isAttacking = false;
        animator.SetBool(animatorBool,false);
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