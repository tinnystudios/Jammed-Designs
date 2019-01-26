using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Image m_TimerImage;
    public TextMeshProUGUI TimerText;

	// Update is called once per frame
	void Update ()
    {
        if (m_TimerImage == null )
        {
            return;
        }

        m_TimerImage.fillAmount = 1 - GameManager.Instance.NormalizedTime;

        double timeRemaining = (double)GameManager.Instance.TimeRemaining;
        TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
        string timeText = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
        TimerText.text = timeText;
        //TimerText = GameManager.Instance.TimeRemaining.ToString("00:00");

    }
}
