using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftGateSC : MonoBehaviour {
    [SerializeField]
    int value;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            RCC_CarControllerV3 car = other.GetComponent<RCC_CarControllerV3>();
            if (car.IsDrifting)
            {
                
                other.GetComponent<RCC_CameraConfig>().points += value;
            }
        }
    }
}
