using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityStates : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private EventOptions ShowEvent;
    [SerializeField] private EventOptions HideEvent;

    [System.Serializable]
    public enum EventOptions
    {
        Paused,
        SettingUp,
        Started,
        Ended,
    };

    // Use this for initialization
    void Start ()
    {
        switch (ShowEvent)
        {
            case EventOptions.Paused:
                GameManager.Instance.Paused += Show;
                break;
            case EventOptions.SettingUp:
                GameManager.Instance.SettingUp += Show;
                break;
            case EventOptions.Started:
                GameManager.Instance.Started += Show;
                break;
            case EventOptions.Ended:
                GameManager.Instance.Ended += Show;
                break;
            default:
                break;
        }

        switch (HideEvent)
        {
            case EventOptions.Paused:
                GameManager.Instance.Paused += Hide;
                break;
            case EventOptions.SettingUp:
                GameManager.Instance.SettingUp += Hide;
                break;
            case EventOptions.Started:
                GameManager.Instance.Started += Hide;
                break;
            case EventOptions.Ended:
                GameManager.Instance.Ended += Hide;
                break;
            default:
                break;
        }

    }
	
	// Update is called once per frame
	void Hide ()
    {
        Target.SetActive(false);
    }

    void Show()
    {
        Target.SetActive(true);
    }
}
