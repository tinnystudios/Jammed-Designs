using JammedDesigns.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipMenu : MonoBehaviour {
    private GameObject m_Target;
    private ManipulationController cont;
    public void Init(GameObject go, ManipulationController controller)
    {
        m_Target = go;
        cont = controller;
    }

    public void Delete()
    {
        var item = m_Target.GetComponent<Item>();
        if (item != null)
        {
            item.ConnectedNode.DetachItem(item);
            var gridZone = item.GetComponentInChildren<GridZoneSensor>(includeInactive: true);
            if (gridZone != null)
            {
                gridZone.ClearNodes();
            }
        }

        Destroy(m_Target);

        cont.ClearMenu();
        print(gameObject);
    }

    public void Accept()
    {
        cont.ClearMenu();
    }

    public void Rotate(float yRotDelta)
    {
        m_Target.transform.eulerAngles += new Vector3(0,yRotDelta,0);
    }
}
