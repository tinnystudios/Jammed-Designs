using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHighlighter : MonoBehaviour
{
    public bool IsValid = true;

    private void OnTriggerStay(Collider col)
    {
        var gridNode = col.GetComponentInParent<GridNode>();

        if (gridNode != null)
        {
            if (!gridNode.Usable)
            {
                IsValid = false;
            }

            if (IsValid)
                gridNode.Highlight();
            else
                gridNode.Invalid();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        var gridNode = col.GetComponentInParent<GridNode>();
        if (gridNode != null)
        {
            gridNode.UnHighlight();
        }
    }
}
