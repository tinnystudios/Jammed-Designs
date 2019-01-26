using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        GameManager.Instance.CurrentState = GameManager.SystemState.Running;
        Destroy(gameObject);
    }

}
