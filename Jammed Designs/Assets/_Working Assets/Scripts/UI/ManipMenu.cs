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
