using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointsFabric {

    public virtual void Spawn(GameObject[] SpawnPoints, GameObject[] SpawnObjects)
    {
        GameObject spawnedObject = MonoBehaviour.Instantiate(SpawnObjects[0],
                              SpawnPoints[0].transform.position,
                              new Quaternion(SpawnPoints[0].transform.localRotation.x, SpawnPoints[0].transform.localRotation.y, SpawnPoints[0].transform.localRotation.z, SpawnPoints[0].transform.localRotation.w));
       
        
    }
}
