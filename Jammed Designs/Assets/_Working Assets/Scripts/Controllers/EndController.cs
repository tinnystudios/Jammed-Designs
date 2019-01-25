using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameManager.Instance.Ended += End;
	}
	
	
    private void End()
    {
        print("Game has ended");
    }
}
