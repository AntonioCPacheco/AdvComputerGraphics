using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Physical_Behaviour : MonoBehaviour {

    public int maxCollisions = 4;
    private int numCollisions = 0;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        if(this.transform.parent != null)
        {
            this.transform.Find("Trigger").GetComponent<Ball_Mechanics>().setCreator(this.transform.parent);
        }
        this.transform.parent = null;

        AudioClip aClip = Resources.Load<AudioClip>("Sound Assets/DogFX");
        SoundManager.instance.RandomizeSfx(aClip);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            numCollisions++;
            if (numCollisions >= maxCollisions) GameObject.Destroy(this.gameObject);
        }
    }
}
