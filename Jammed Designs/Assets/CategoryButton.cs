using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour, IPointerClickHandler
{
    public CanvasGroup CategoryButtonGroup;
    public TextMeshProUGUI Title;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlayClick();
    }

    public void InActive()
    {
        CategoryButtonGroup.alpha = 0.5F;
    }

    public void Active()
    {
        CategoryButtonGroup.alpha = 0.8F;
    }

    public void SetTitle(string title)
    {
        Title.text = title;
    }
}
