using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSurvival : PointsFabric
{
    public override void Spawn(GameObject[] SpawnPoints, GameObject[] SpawnObjects)
    {
       
        foreach (GameObject point in SpawnPoints)
        {
            if (point.GetComponent<PointScript>().busy == false)
            {

                GameObject spawnedObject = MonoBehaviour.Instantiate(SpawnObjects[0],
                            point.transform.position,
                            new Quaternion(point.transform.localRotation.x, point.transform.localRotation.y, point.transform.localRotation.z, point.transform.localRotation.w));
                   
                  
                    spawnedObject.transform.parent = point.transform;
                    point.GetComponent<PointScript>().busy = true;
                
            }
        }
    }
}
