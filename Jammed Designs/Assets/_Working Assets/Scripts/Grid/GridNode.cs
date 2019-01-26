using JammedDesigns.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//These Nodes are left aligned
public class GridNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item SelectedItem;
    public Transform Center;

    public Color InvalidColor = Color.red;
    public Color HighlightColor = Color.blue;
    public Color DefaultColor = Color.white;

    public bool Usable
    {
        get
        {
            return _usable;
        }
    }

    public void SetColor(Color color)
    {
        var renderer = GetComponentInChildren<Renderer>();
        var mat = renderer.material;
        mat.color = color;
    }

    public void Highlight()
    {
        SetColor(HighlightColor);
    }

    public void UnHighlight()
    {
        SetColor(DefaultColor);
    }

    public void Invalid()
    {
        SetColor(InvalidColor);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Highlight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnHighlight();
    }

    public void AttachItem(Item item)
    {
        SelectedItem = item;
        SetUsabilitity(false);
        item.Init(this);
    }

    public void DetachItem(Item item)
    {
        SelectedItem = null;
        SetUsabilitity(true);
    }

    public void SetUsabilitity(bool state)
    {
        _usable = state;
    }

    private bool _usable = true;
}
