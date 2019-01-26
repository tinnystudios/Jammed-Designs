using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerController : MonoBehaviour
{
    [SerializeField] private Image m_TimerImage;
	
	// Update is called once per frame
	void Update ()
    {
        if (m_TimerImage == null )
        {
            return;
        }

        m_TimerImage.fillAmount = 1 - GameManager.Instance.NormalizedTime;

    }
}
