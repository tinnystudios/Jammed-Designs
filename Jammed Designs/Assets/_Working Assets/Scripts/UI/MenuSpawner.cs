using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {
    public GameObject MenuToSpawn;
	public void SpawnMenu()
    {
        var go = Instantiate(MenuToSpawn);
        go.transform.SetParent(transform.parent);
        go.GetComponent<RectTransform>().transform.position = Vector3.zero;
        Time.timeScale = 0;
        GameManager.Instance.CurrentState = GameManager.SystemState.Paused;
    }
}
