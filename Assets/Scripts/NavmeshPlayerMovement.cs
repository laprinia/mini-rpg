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
        }

       
      
    }
}
