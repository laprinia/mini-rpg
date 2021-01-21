using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAround : MonoBehaviour
{
    public float rotationSpeed;
    public Transform targetPlayer;
    private float yaw;

 

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            {
                targetPlayer.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                yaw += rotationSpeed * Input.GetAxis("Mouse X");
                while (yaw < 0f)
                {
                    yaw += 360f;
                }
                while (yaw >= 360f)
                {
                    yaw -= 360f;
                }
                targetPlayer.transform.eulerAngles = new Vector3(0, yaw, 0f);
              
            }

        }
        else if(Input.GetKey (KeyCode.E))
        {
            transform.RotateAround(targetPlayer.transform.position, Vector3.up, rotationSpeed * Time.deltaTime*20);
        }
        else if(Input.GetKey (KeyCode.Q))
        {
            transform.RotateAround(targetPlayer.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime*20);
        }

    }
}