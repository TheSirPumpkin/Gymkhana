using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerFollow : MonoBehaviour {
    GameController main;
    // Use this for initialization
    void Start () {
        main = GameController.instance;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 objectLine = (main.p1.transform.position - main.p2.transform.position);
        objectLine = objectLine.normalized;
        transform.position = objectLine + new Vector3(0, 35, 0);
    }
}
