using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour {

    Slider _MasterSlider;
    Slider _MusicSlider;
    Slider _EffectsSlider;

    Toggle _MasterToggle;
    Toggle _MusicToggle;
    Toggle _EffectsToggle;

    // Use this for initialization
    void Start () {
        _MasterSlider = this.transform.Find("MasterSlider").GetComponent<Slider>();
        _MasterToggle = this.transform.Find("MasterToggle").GetComponent<Toggle>();

        _MusicSlider = this.transform.Find("MusicSlider").GetComponent<Slider>();
        _MusicToggle = this.transform.Find("MusicToggle").GetComponent<Toggle>();

        _EffectsSlider = this.transform.Find("EffectsSlider").GetComponent<Slider>();
        _EffectsToggle = this.transform.Find("EffectsToggle").GetComponent<Toggle>();
    }
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = (_MasterSlider.value / 100); //Adjusting the master volume based on the slider
        AudioListener.volume *= _MasterToggle.isOn ? 1 : 0; //Toggling the volume off or on

        SoundManager.instance.SetMusicVolume((_MusicSlider.value / 100) * (_MusicToggle.isOn ? 1 : 0));

    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonUp(0))
            SoundManager.instance.SetEffectsVolume((_EffectsSlider.value / 100) * (_EffectsToggle.isOn ? 1 : 0));
    }
}
