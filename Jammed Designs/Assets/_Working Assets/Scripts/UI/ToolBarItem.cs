using JammedDesigns.Model;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarItem : MonoBehaviour
{
    public static Action<GameObject> OnCreateItem;

    public LayerMask NodeLayer;

    //Data Structure
    public Item ItemPrefab;
    public Sprite Icon;

    //Views
    public Image ItemIcon;
    public Image Thumbnail;

    public GridHighlighter GridHighlighterPrefab;

    public GameObject ghost;

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
        bool created = false;

        if (gridNode != null && gridNode.SelectedItem == null && gridNode.Usable && _gridHighlighter.IsValid)
        {
            var itemObject = Instantiate(ItemPrefab, gridNode.Center.position, Quaternion.identity);
            itemObject.transform.eulerAngles = _gridHighlighter.transform.eulerAngles;
            gridNode.AttachItem(itemObject);

            Debug.Log("Enabling : " + itemObject.transform.GetChild(1).name);
            itemObject.transform.GetChild(1).gameObject.SetActive(true);
            itemObject.GetComponent<Collider>().enabled = true;
            created = true;
        }

        // #TODO Refactor
        var nodes = FindObjectsOfType<GridNode>();
        foreach (var node in nodes)
        {
            node.UnHighlight();
        }

        // #TODO Refactor after merging
        Destroy(_gridHighlighter.gameObject);
        Destroy(ghost);

        if (created)
        {
            AudioManager.Instance.PlaySelect();
        }
        else
        {
            AudioManager.Instance.PlayError();
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(_gridHighlighter != null)
            _gridHighlighter.transform.eulerAngles += new Vector3(0, 90, 0);
        }

        if (ghost != null && _gridHighlighter != null)
        {
            ghost.transform.position = _gridHighlighter.transform.position;
            ghost.transform.eulerAngles = _gridHighlighter.transform.eulerAngles;
        }
    }

    public void SetupHighlight()
    {
        var gridNode = GetGridNode;
        var itemPrefabZoneSensor = ItemPrefab.GetComponentInChildren<GridZoneSensor>(includeInactive: true);

        if (_gridHighlighter == null)
            _gridHighlighter = Instantiate(GridHighlighterPrefab);

        _gridHighlighter.transform.rotation = itemPrefabZoneSensor.transform.rotation;
        _gridHighlighter.transform.localScale = itemPrefabZoneSensor.transform.localScale;

        ghost = Instantiate(ItemPrefab.gameObject, _gridHighlighter.transform.position, _gridHighlighter.transform.rotation);
        //remove the highligheter from the ghost

        _gridHighlighter.gameObject.SetActive(true);
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
            _gridHighlighter.IsValid = gridNode.Usable;
            _gridHighlighter.transform.position = gridNode.Center.position;

            var itemPrefabZoneSensor = ItemPrefab.GetComponentInChildren<GridZoneSensor>(includeInactive: true);

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

            if (Physics.Raycast(ray, out hit, NodeLayer))
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
