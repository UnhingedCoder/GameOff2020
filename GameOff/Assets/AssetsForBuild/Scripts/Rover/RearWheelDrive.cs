using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearWheelDrive : MonoBehaviour
{
    private WheelCollider[] wheels;

    public float maxAngle = 30f;
    public float maxTorque = 300f;

    public GameObject wheelShape;


    private void Start()
    {
        Init();
    }

    //Fetch all wheel colliders
    void Init()
    {
        wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];

            //Create wheel shapes if needed
            if (wheelShape != null)
            {
                var ws = GameObject.Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }
    }

    private void Update()
    {
        MoveRearWheel();
    }

    void MoveRearWheel()
    {
        float angle = maxAngle * Input.GetAxis("Horizontal");
        float torque = maxTorque * Input.GetAxis("Vertical");

        foreach(WheelCollider wheel in wheels)
        {
            if (wheel.transform.localPosition.z > 0)
                wheel.steerAngle = angle;

            if (wheel.transform.localPosition.z < 0)
                wheel.motorTorque = torque;

            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;

                wheel.GetWorldPose(out p, out q);

                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;
            }
        }
    }
}
