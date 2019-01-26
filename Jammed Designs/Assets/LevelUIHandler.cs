using System;
using TMPro;
using UnityEngine;

public class LevelUIHandler : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public GameObject Timer;
    public GameObject Menu;

    private void Awake()
    {
        Timer.SetActive(false);
        Menu.SetActive(false);

        GameManager.Instance.Started += OnGameStart;
        LevelText.enabled = false;
        LevelText.text = string.Format("LEVEL {0}", LevelManager.Instance.Level);
    }

    private void OnDestroy()
    {
        GameManager.Instance.Started -= OnGameStart;
    }

    private void OnGameStart()
    {
        LevelText.enabled = true;
        Timer.SetActive(true);
        Menu.SetActive(true);
    }
}
