using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    SteeringWheel wheel;
    public float motor;
    public float steering;
    public float touchAccel;
    void Start()
    {
        wheel = FindObjectOfType<SteeringWheel>();
    }

    public void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0)
            motor = maxMotorTorque * Input.GetAxis("Vertical");
        else
            motor = maxMotorTorque * touchAccel;

        if (Input.GetAxis("Horizontal") != 0)
            steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        else
            steering = maxSteeringAngle * wheel.GetClampedValue();


        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void TouchSteering(float amount)
    {
        touchAccel = amount;
    }
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

 
