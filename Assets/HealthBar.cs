using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthBar : MonoBehaviour {

    public GameObject _Player;
    private int _CurrentHP;
    const string _Display = "{0}  H P";
    private Text _Text;

    private bool _Started = false;

    void Start()
    {
        _Text = GetComponent<Text>();
    }


    void Update()
    {
        if (!_Started)
        {
            UpdateHealthBar();
            _Started = true;
        }
    }

    public void UpdateHealthBar()
    {
        _CurrentHP = _Player.GetComponent<PlayerHealthManager>().GetCurrentHealth();
        _Text.text = string.Format(_Display, _CurrentHP);
    }
}
