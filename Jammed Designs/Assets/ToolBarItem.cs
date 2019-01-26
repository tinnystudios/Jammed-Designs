using System;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarItem : MonoBehaviour
{
    public static Action<GameObject> OnCreateItem;

    //Data Structure
    public Item ItemPrefab;
    public Sprite Icon;

    //Views
    public Image ItemIcon;
    public Image Thumbnail;

    public GridHighlighter GridHighlighterPrefab;

    //Once it's all hooked up, we won't need this.
    private void Awake()
    {
        SetDisplayImages(Icon);
    }

    //Bind Data externally during creation
    public void BindData(Item itemPrefab, Sprite icon, string descriptions)
    {
        ItemPrefab = itemPrefab;
        Icon = icon;

        SetDisplayImages(Icon);
    }

    public void SetDisplayImages(Sprite icon)
    {
        Thumbnail.sprite = Icon;
        ItemIcon.sprite = Icon;

        Thumbnail.enabled = false;
    }

    //Create Item and place it in the 3D Space. 
    public void CreateItem()
    {
        var gridNode = GetGridNode;

        if (gridNode != null && gridNode.SelectedItem == null && gridNode.Usable && _gridHighlighter.IsValid)
        {
            var itemObject = Instantiate(ItemPrefab, gridNode.Center.position, Quaternion.identity);
            gridNode.AttachItem(itemObject);
        }

        // #TODO Refactor
        var nodes = FindObjectsOfType<GridNode>();
        foreach (var node in nodes)
        {
            node.UnHighlight();
        }

        // #TODO Refactor after merging
        Destroy(_gridHighlighter);
    }

    public void TryHighlightGrid()
    {
        var gridNode = GetGridNode;

        if (gridNode != null)
        {
            if (_selectedGridNode != null && _selectedGridNode != gridNode)
            {
                _selectedGridNode.UnHighlight();
            }

            _selectedGridNode = gridNode;

            //Set size
            var itemPrefabZoneSensor = ItemPrefab.GetComponentInChildren<GridZoneSensor>();

            if(_gridHighlighter == null)
                _gridHighlighter = Instantiate(GridHighlighterPrefab);

            _gridHighlighter.transform.rotation = itemPrefabZoneSensor.transform.rotation;
            _gridHighlighter.transform.localScale = itemPrefabZoneSensor.transform.localScale;
            _gridHighlighter.transform.position = gridNode.Center.position;
            _gridHighlighter.IsValid = gridNode.Usable;

            _gridHighlighter.gameObject.SetActive(true);

            if (gridNode.Usable)
            {
                gridNode.Highlight();
            }
            else
            {
                gridNode.Invalid();
            }
        }
    }

    public GridNode GetGridNode
    {
        get
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var gridNode = hit.transform.GetComponentInParent<GridNode>();
                return gridNode;
            }

            return null;
        }         
    }

    private GridNode _selectedGridNode;
    private GridHighlighter _gridHighlighter;
}
