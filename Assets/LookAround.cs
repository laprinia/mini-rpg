using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}