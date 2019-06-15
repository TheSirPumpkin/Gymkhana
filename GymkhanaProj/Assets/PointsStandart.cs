using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsStandard : PointsFabric
{
    public override void Spawn(GameObject[] SpawnPoints, GameObject[] SpawnObjects)
    {
        GameObject spawnedObject = SpawnObjects[0].gameObject;
        foreach (GameObject point in SpawnPoints)
        {
            if (point.GetComponent<PointScript>().busy == false)
            {
                int chance = Random.Range(0, 2);// chance to spawn anything at all
                if (chance != 0)
                {
                    //chance to spawn specific object
                    int chanceSpec = Random.Range(0, 6);
                    if (chanceSpec > 0)
                    {
                        spawnedObject = MonoBehaviour.Instantiate(SpawnObjects[0],
                            point.transform.position,
                            new Quaternion(point.transform.localRotation.x, point.transform.localRotation.y, point.transform.localRotation.z, point.transform.localRotation.w));
                    }
                    else
                    {
                        spawnedObject = MonoBehaviour.Instantiate(SpawnObjects[1],
                         point.transform.position,
                         new Quaternion(point.transform.localRotation.x, point.transform.localRotation.y, point.transform.localRotation.z, point.transform.localRotation.w));
                    }
                    spawnedObject.transform.parent = point.transform;
                    point.GetComponent<PointScript>().busy = true;
                }
            }
        }
    }

}
