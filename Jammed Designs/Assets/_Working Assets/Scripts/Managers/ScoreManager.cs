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

    //All below should be In ScoreMenuBoardUI, oh well D:
    public TextMeshProUGUI LevelClearText;
    public TextMeshProUGUI CommentText;
    public List<GameObject> Stars;
    public GameObject NextButton;

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

    //1Star fail, 2Stars pass, 3Stars perfect!
    //Get score and leave different comments and stars for it.
    public void UpdateNextMenuBoard(bool isCompleted)
    {
        foreach (var star in Stars)
        {
            star.SetActive(false);
        }

        //The comments should be in the Level script.
        string comment = "";

        if (isCompleted)
        {
            switch (LevelManager.Instance.Level)
            {
                case 1:
                    comment = "Homey";
                    break;

                case 2:
                    comment = "Brrrrrrrr";
                    break;

                case 3:
                    comment = "Very futuristic!";
                    break;

                case 4:
                    comment = "Fin";
                    break;
            }

            foreach (var star in Stars)
            {
                star.SetActive(true);
            }

            LevelClearText.text = string.Format("LEVEL {0} CLEARED!", LevelManager.Instance.Level);
        }
        else
        {
            switch (LevelManager.Instance.Level)
            {
                case 1:
                    comment = "I just want warm orangey things...";
                    break;

                case 2:
                    comment = "What color does Winter remind you off?";
                    break;

                case 3:
                    comment = "Once again, Good Luck!";
                    break;

                case 4:
                    comment = "I'm honestly out of comments";
                    break;
            }

            Stars[0].SetActive(true);
            LevelClearText.text = string.Format("LEVEL {0} FAILED...", LevelManager.Instance.Level);
        }

        CommentText.text = comment;
        NextButton.SetActive(isCompleted);
    }
}
