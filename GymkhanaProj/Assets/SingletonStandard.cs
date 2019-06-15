using UnityEngine;
using System.Collections;

public class SingletonStandard : Singleton
{
    public static SingletonStandard instance;
    public bool isPersistant;

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