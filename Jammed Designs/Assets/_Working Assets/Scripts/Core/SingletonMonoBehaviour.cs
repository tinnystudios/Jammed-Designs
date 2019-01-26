using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool DontDestroyObjectOnLoad = false;

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);

        _instance = this as T;

        if (DontDestroyObjectOnLoad)
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
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
