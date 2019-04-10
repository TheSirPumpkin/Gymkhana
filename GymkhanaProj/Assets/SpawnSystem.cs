using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {
    public static SpawnSystem instance;
    public Transform[] SpawnPoints, SpawnObjects;
    float timer;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timer = 20;
        foreach (Transform point in SpawnPoints)
        {
            Transform spawnedObject = Instantiate(SpawnObjects[Random.Range(0, SpawnObjects.Length)], point.position, new Quaternion (point.localRotation.x, point.localRotation.y, point.localRotation.z, point.localRotation.w));
            spawnedObject.parent = point;
            point.GetComponent<PointScript>().busy = true;
        }
    }
	public void Respawn()
    {

        foreach (Transform point in SpawnPoints)
        {
            if (point.GetComponent<PointScript>().busy == false)
            {
                int chance = Random.Range(0, 2);
                if (chance != 0)
                {
                    Transform spawnedObject = Instantiate(SpawnObjects[Random.Range(0, SpawnObjects.Length)], point.position, new Quaternion(point.localRotation.x, point.localRotation.y, point.localRotation.z, point.localRotation.w));
                    spawnedObject.parent = point;
                    point.GetComponent<PointScript>().busy = true;
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Respawn();
            timer = 20;
        }

    }
}
