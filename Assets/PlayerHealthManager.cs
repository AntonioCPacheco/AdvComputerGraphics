using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int _maxHealth = 3;
    private int _currentHealth;

	// Use this for initialization
	void Start () {
        _currentHealth = _maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0) FindObjectOfType<GameManager>().GameOver(this.transform);
        HealthBar[] hb = FindObjectsOfType<HealthBar>();
        for(int i=0; i < hb.Length; i++)
        {
            hb[i].UpdateHealthBar();
        }
    }
}
