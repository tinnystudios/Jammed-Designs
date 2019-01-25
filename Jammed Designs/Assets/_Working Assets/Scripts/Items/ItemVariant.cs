using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVariant : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string ItemName;
        public Sprite ItemSprite;
        public GameObject ItemPrefab;
    }


    
}
