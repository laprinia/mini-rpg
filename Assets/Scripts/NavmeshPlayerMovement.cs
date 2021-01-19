using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NavmeshPlayerMovement : MonoBehaviour
{
   // public ThirdPersonCharacter character;
    public NavMeshAgent agent;
    public Camera mainCamera;
    public Animator animator;

    private void Start()
    {
        // agent.updateRotation = false;
    }
    protected bool pathComplete()
    {
        if ( Vector3.Distance( agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }
        return false;
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                animator.SetTrigger("isWalkingTrigger");
                agent.SetDestination(hit.point);
               
            }
        }

        if (pathComplete()) StartCoroutine(StopAnimationCoroutine());
      
    }

    IEnumerator StopAnimationCoroutine()
    {
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("isNotWalkingTrigger");
        
    }
}
