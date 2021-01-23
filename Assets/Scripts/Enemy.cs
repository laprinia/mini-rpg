using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    private Health health;
    public float viewRadius = 5;
    public float attackRadius = 2;
    public NavMeshAgent agent;
    private float attackTimeStamp = 2f;
    private float walkTimeStamp = 5f;
    private int attackCoolDown = 3;
    private int walkCoolDown = 5;
    
    public Transform target;
    private Sanity sanityScript;
    private Luck luckScript;
    private float curSpeed;
    private Vector3 lastPosition;

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position,viewRadius);
    }

    private void Start()
    {
        lastPosition = transform.position;
        sanityScript = target.GetComponent<Sanity>();
        luckScript = target.GetComponent<Luck>();
        health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        float currentSpeed = (transform. position - lastPosition).magnitude;
        animator.SetFloat("speed",currentSpeed*10);
        Debug.Log(currentSpeed* 10);
        lastPosition = transform. position;
    }
    
    private void Update()
    {
   
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= viewRadius)
        {
            
            FaceTarget();
            agent.SetDestination(target.position);
     ;
            if(distance <= attackRadius && Time.time>=attackTimeStamp) 
            {
                attackTimeStamp = Time.time + attackCoolDown;
                animator.SetTrigger("isAttacking");
                sanityScript.RemoveSanity(25);

            }
        }
        else if (Time.time>=walkTimeStamp)
        {
                walkTimeStamp = Time.time + walkCoolDown;
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
                agent.SetDestination(waypoints[currentWaypoint].position);
        }
        
    }
    
    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

   
    public void TakeDamage(int amount)
    {
        health.RemoveHealth(amount);
        if (health.maxHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private void OnMouseOver()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("isDying");
        
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }
}