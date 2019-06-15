using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    public static Singleton instance;
    public bool isPersistant;
    public GameObject[] modes;

    public virtual void Awake()
    {

        if (isPersistant)
        {
            if (!instance)
            {
                instance = this;
            }
            else
            {
                DestroyObject(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
