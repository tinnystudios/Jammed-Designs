using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    public int SenseValue;
    public Tag SensationEvoked;
    public ItemType TypeOfItem;

    [System.Serializable]
    public enum Tag
    {
        Warm,
        Cold,
        Modern,
        Rustic,
        Retro,
        Futuristic,
    };

    [System.Serializable]
    public enum ItemType
    {
        TV,
        Couch,
        Chair,
        Fireplace,
        Picture,
        Rug,
        Table,
    };

}
