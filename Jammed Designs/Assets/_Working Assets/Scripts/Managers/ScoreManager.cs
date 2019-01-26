using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameObject SliderPrefab;
    public GameObject CheckboxPrefab;
    public Transform SliderParent, CheckboxParent;


    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void MakeSlider(int scoreValue, string title)
    {
        var go = Instantiate(SliderPrefab);
        go.transform.SetParent(SliderParent);
        go.GetComponentInChildren<TextMeshProUGUI>().text = title;
        go.GetComponentInChildren<Slider>().minValue = -10;
        go.GetComponentInChildren<Slider>().maxValue = 10;
        go.GetComponentInChildren<Slider>().wholeNumbers = true;
        go.GetComponentInChildren<Slider>().value = scoreValue;
    }

    public void MakeCheckbox(int curCount, int numWanted, string objText)
    {
        var go = Instantiate(CheckboxPrefab);
        go.transform.SetParent(CheckboxParent);
        go.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0}/{1} {2}",curCount,numWanted, objText);

        if (curCount>=numWanted)
        {
            go.GetComponentInChildren<Toggle>().isOn = true;
        }
        else
        {
            go.GetComponentInChildren<Toggle>().isOn = false;
        }
    }
}
