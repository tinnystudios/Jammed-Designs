using System.Collections;
using TMPro;
using UnityEngine;

public class DialougeBox : MonoBehaviour
{
    public TextMeshProUGUI DialougeText;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string dialougeText)
    {
        DialougeText.text = dialougeText;
    }
}