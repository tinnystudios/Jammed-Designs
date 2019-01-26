using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationController : MonoBehaviour
{
    [SerializeField] GameObject m_ManipMenuPrefab;
    [SerializeField] Transform m_MenuSpawned;
    [SerializeField] GameObject m_ManipMenu;
    // Use this for initialization
    void Start () {
        GameManager.Instance.Ended += ClearMenu;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Input.GetMouseButtonDown(0)) return;

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);


        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.GetComponent<JammedDesigns.Model.Item>())
            {
                if (m_ManipMenu != null)
                {
                    ClearMenu();
                }
                
                SpawnManipulationMenu(hit.collider.gameObject);
            }
        }
    }

    private void SpawnManipulationMenu(GameObject target)
    {
        var spawnPos = Camera.main.WorldToScreenPoint(target.transform.position);
        var go = Instantiate(m_ManipMenuPrefab);
        m_ManipMenu = go;
        go.transform.SetParent(m_MenuSpawned);
        go.GetComponent<RectTransform>().position = spawnPos;

        go.GetComponent<ManipMenu>().Init(target, this);
    }

    public void ClearMenu()
    {
        if(m_ManipMenu!=null)
        {
            Destroy(m_ManipMenu);
            m_ManipMenu = null;
        }
    }
}
