using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ToolBarItem))]
public class ToolBarItemButton : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private ToolBarItem ToolBarItem;

    private void OnValidate()
    {
        ToolBarItem = GetComponent<ToolBarItem>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ToolBarItem.Thumbnail.enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ToolBarItem.Thumbnail.transform.position = MousePositionToCanvasWorld;
        ToolBarItem.TryHighlightGrid();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ToolBarItem.Thumbnail.transform.position = transform.position;
        ToolBarItem.Thumbnail.enabled = false;

        ToolBarItem.CreateItem();
    }

    private Vector3 MousePositionToCanvasWorld
    {
        get
        {
            Vector2 pos;
            var parentCanvas = GetComponentInParent<Canvas>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentCanvas.transform as RectTransform, Input.mousePosition,
                parentCanvas.worldCamera,
                out pos);

            return parentCanvas.transform.TransformPoint(pos);
        }
    }
}
