using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointObject : MonoBehaviour {
    public int value;
    public GameObject dead, toDisable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RCC_CameraConfig>())
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
            if (value < 0 && other.GetComponent<RCC_CameraConfig>().player == 1)
            {
                GameController.instance.p1Minus.SetActive(true);
            }
            if (value > 0 && other.GetComponent<RCC_CameraConfig>().player == 1)
            {
                GameController.instance.p1Plus.SetActive(true);
            }
            if (value < 0 && other.GetComponent<RCC_CameraConfig>().player == 2)
            {
                GameController.instance.p2Minus.SetActive(true);
            }
            if (value > 0 && other.GetComponent<RCC_CameraConfig>().player == 2)
            {
                GameController.instance.p2Plus.SetActive(true);
            }
            dead.SetActive(true);
            toDisable.SetActive(false);
            //SpawnSystem.instance.Respawn(this.transform);
            other.GetComponent<RCC_CameraConfig>().points += value;
            transform.parent.GetComponent<PointScript>().busy = false;
            Destroy(gameObject,0.5f);
        }
    }
}
