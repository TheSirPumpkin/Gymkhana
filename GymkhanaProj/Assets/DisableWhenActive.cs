using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenActive : MonoBehaviour {

    // Use this for initialization
    private void OnEnable()
    {
        Invoke("Dis", 1);
    }

    private void Dis()
    {
        gameObject.SetActive(false);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
