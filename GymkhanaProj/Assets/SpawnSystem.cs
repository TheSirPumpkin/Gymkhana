using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {
    public static SpawnSystem instance;
    GameObject[] SpawnPoints, SpawnObjects;
    float timer;
    PointsFabric Fabric;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
        if (GameObject.Find("Standard"))
        {
            Fabric = new PointsStandard();
            SpawnObjects = Resources.LoadAll<GameObject>("StandardPoints");
            SpawnPoints = GameObject.FindGameObjectsWithTag("StandardPoint");
        }

        if (GameObject.Find("Survival"))
        {
            Fabric = new PointsSurvival();
            SpawnObjects = Resources.LoadAll<GameObject>("SurvivalPoints");
            SpawnPoints = GameObject.FindGameObjectsWithTag("SurvivalPoint");
        }
    }
    void Start()
    {
        timer = 20;
        Fabric.Spawn(SpawnPoints, SpawnObjects);
    }
	public void Respawn()
    {
       //пока не используется
        Fabric.Spawn(SpawnPoints, SpawnObjects);
    }
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Fabric.Spawn(SpawnPoints, SpawnObjects);
            timer = 20;
        }

    }
}
