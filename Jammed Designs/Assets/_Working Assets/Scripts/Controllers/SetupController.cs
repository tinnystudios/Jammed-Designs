using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupController : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_FloorTiles;
    private List<Vector3> m_FloorTilesStartPos;
    [SerializeField] private List<GameObject> m_Walls;
    private List<Vector3> m_WallsStartPos;
    [SerializeField] private AnimationCurve m_DropCurve;

    // Use this for initialization
    void Start ()
    {
        GameManager.Instance.SettingUp += SettingUpGame;
        m_FloorTilesStartPos = new List<Vector3>();
        m_WallsStartPos = new List<Vector3>();

        foreach (var item in m_FloorTiles)
        {
            m_FloorTilesStartPos.Add(item.transform.position);
            item.transform.position += new Vector3(0, 20, 0);
        }

        foreach (var item in m_Walls)
        {
            m_WallsStartPos.Add(item.transform.position);
            item.transform.position += new Vector3(0, 20, 0);
        }
    }
	
	
    private void SettingUpGame()
    {
        StartCoroutine(DropItems());
    }

    private void StartGame()
    {
        if (GameManager.Instance.Started != null) 
        {
            GameManager.Instance.Started.Invoke();
        }
    }

    private IEnumerator DropItems()
    {
        for (int i = 0; i < m_FloorTiles.Count; i++)
        {
            StartCoroutine(DropRoutine(m_FloorTiles[i], i, m_FloorTilesStartPos));
            yield return new WaitForSeconds(5f / m_FloorTiles.Count);
        }

        for (int i = 0; i < m_Walls.Count; i++)
        {
            StartCoroutine(DropRoutine(m_Walls[i], i, m_WallsStartPos));
            yield return new WaitForSeconds(5f / m_FloorTiles.Count);
        }

        StartGame();
    }

    private IEnumerator DropRoutine(GameObject droppedObject, int index,List<Vector3> StartPoses)
    {
        float elapsedTime = 0;

        var newPos = StartPoses[index];
        while (elapsedTime < m_DropCurve.keys[1].time)
        {
            elapsedTime += Time.deltaTime;
            newPos = StartPoses[index] + new Vector3(0, m_DropCurve.Evaluate(elapsedTime), 0);

            droppedObject.transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }
    }
}
