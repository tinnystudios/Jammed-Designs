using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    public int SenseValue;
    public Tag SensationEvoked;

    [System.Serializable]
    public enum Tag
    {
        Warm,
        Cold,
        Modern,
        Rustic,
        Retro,
        Futuristic,
        Neutral,
    };

}
