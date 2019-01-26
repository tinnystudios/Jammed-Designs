using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);

        _instance = this as T;
    }

    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<T>();

            return _instance;
        }
    }

    private static T _instance;
}
