﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class SuspensionControl : MonoBehaviour
{
    [Range(0, 20)]
    public float naturalFrequency = 10;

    [Range(0, 3)]
    public float dampingRatio = 0.8f;

    [Range(-1, 1)]
    public float forceShift = 0.03f;

    public bool setSuspensionDistance = true;

    private void Update()
    {
        HandleSuspension();    
    }

    void HandleSuspension()
    {
        //Calculate stiffness and damper parameters based on the better spring model
        foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>())
        {
            JointSpring spring = wc.suspensionSpring;

            spring.spring = Mathf.Pow(Mathf.Sqrt(wc.sprungMass) * naturalFrequency, 2);
            spring.damper = 2 * dampingRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);

            wc.suspensionSpring = spring;

            Vector3 wheelRelativeBody = transform.InverseTransformPoint(wc.transform.position);
            float distance = GetComponent<Rigidbody>().centerOfMass.y - wheelRelativeBody.y + wc.radius;

            wc.forceAppPointDistance = distance - forceShift;

            // Make sure the spring force at maximum droop is exactly zero
            if (spring.targetPosition > 0 && setSuspensionDistance)
                wc.suspensionDistance = wc.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
        }
    }
}
