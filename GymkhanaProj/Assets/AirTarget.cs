using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTarget : MonoBehaviour {
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            RCC_CarControllerV3 car = other.GetComponent<RCC_CarControllerV3>();
            if (car.speed>70)
            {

                other.GetComponent<RCC_CameraConfig>().points +=700;
            }
            else other.GetComponent<RCC_CameraConfig>().points += 300;
        }
    }
}
