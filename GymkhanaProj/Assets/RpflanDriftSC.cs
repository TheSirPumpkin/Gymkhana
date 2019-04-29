using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpflanDriftSC : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            RCC_CarControllerV3 car = other.GetComponent<RCC_CarControllerV3>();
            if (car.driftingNow)
            {

                other.GetComponent<RCC_CameraConfig>().points++;
            }
         
        }
    }
}
