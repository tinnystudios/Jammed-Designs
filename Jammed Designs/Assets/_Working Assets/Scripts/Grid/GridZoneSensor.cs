using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridZoneSensor : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {
        var gridNode = col.GetComponentInParent<GridNode>();
        if (gridNode != null)
        {
            gridNode.SetUsabilitity(false);
        }
    }
}
