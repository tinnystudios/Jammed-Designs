using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "House Item", menuName = "House/Item", order = 1)]
public class HouseItem : ScriptableObject
{
    public string ItemName;
    public Sprite BaseIcon;
    public List<ItemVariant.Item> ItemVariants;

    public void Rotate(Vector3 rotDelta, GameObject targetObject)
    {
        targetObject.transform.eulerAngles += rotDelta;
    }

  
}
