using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBallScript : MonoBehaviour {

    bool visible = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleAppearance(bool e)
    {
        this.GetComponent<MeshRenderer>().enabled = e;
    }
}
