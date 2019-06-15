using UnityEngine;
using System.Collections;

public class SingletonSurvival : Singleton 
{
    public static SingletonSurvival instance;
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