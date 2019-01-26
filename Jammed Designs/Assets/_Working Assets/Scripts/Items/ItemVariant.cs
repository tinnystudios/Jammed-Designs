using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVariant : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        [TextArea]
        public string ItemDescription;
        public Sprite ItemSprite;
        public JammedDesigns.Model.Item ItemPrefab;
    }
    
}
