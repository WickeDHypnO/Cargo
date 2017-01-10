using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;
public class CarUserControl : MonoBehaviour
{
    public SteeringWheel wheel;
    private CarController m_Car; // the car controller we want to use

    private float touchAccel;
    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }


    private void FixedUpdate()
    {
        // pass the input to the car!
        float h;
        if (Input.GetAxis("Horizontal") != 0)
        {
            h = Input.GetAxis("Horizontal");

        }
        else
        {
            h = wheel.GetClampedValue();
        }

        float v;
        if (Input.GetAxis("Vertical") != 0)
            v = Input.GetAxis("Vertical");
        else
            v = touchAccel;

#if !MOBILE_INPUT
        float handbrake = Input.GetAxis("Jump");
        m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
    }

    public void TouchSteering(float amount)
    {
        touchAccel = amount;
    }
}
