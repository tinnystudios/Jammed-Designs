using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridZoneSensor : MonoBehaviour
{
    public HashSet<GridNode> NodeLookUp = new HashSet<GridNode>();

    private void OnTriggerStay(Collider col)
    {
        var gridNode = col.GetComponentInParent<GridNode>();
        if (gridNode != null)
        {
            gridNode.SetUsabilitity(false);

            if (!NodeLookUp.Contains(gridNode))
            {
                NodeLookUp.Add(gridNode);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        var gridNode = col.GetComponentInParent<GridNode>();
        if (gridNode != null)
        {
            gridNode.UnHighlight();
            NodeLookUp.Remove(gridNode);
        }
    }

    public void ClearNodes()
    {
        foreach (var node in NodeLookUp)
        {
            node.SetUsabilitity(true);
        }

        gameObject.SetActive(false);
    }
}
