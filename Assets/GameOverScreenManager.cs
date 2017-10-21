using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenManager : MonoBehaviour {

    string[] winners = { "O N E", "T W O" };
    const string _Display = "P L A Y E R   {0}   W I N S !";
    private Text _Text;

    void Awake()
    {
        _Text = GetComponent<Text>();
        SetActive(false);
    }

    // Update is called once per frame
    void Update () {

	}

    public void SetWinner(Transform loser)
    {
        if (loser.CompareTag("Draw"))
        {
            _Text.text = "I T ' S   A   D R A W !";
            return;
        }
        _Text.text = string.Format(_Display, winners[(loser.CompareTag("PlayerOne") ? 1 : 0)]);
    }

    public void SetActive(bool b)
    {
        this.transform.parent.parent.gameObject.SetActive(b);
    }
}
