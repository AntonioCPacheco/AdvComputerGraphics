using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Mechanics : MonoBehaviour {

    bool isCreatorP1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.CompareTag("Player" + (isCreatorP1 ? "Two" : "One")))
        {
            coll.transform.GetComponent<PlayerHealthManager>().TakeDamage();
            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }

    public void setCreator(Transform creator)
    {
        isCreatorP1 = creator.CompareTag("PlayerOne");
    }

    public string getCreatorTag()
    {
        return "Player" + (isCreatorP1 ? "One" : "Two");
    }
}
