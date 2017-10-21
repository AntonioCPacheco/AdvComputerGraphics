using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public AudioSource _FxAudioSource;
    public AudioSource _MusicAudioSource;
    public static SoundManager instance = null;

    public AudioClip MenuMusic;
    public AudioClip PlayMusic;

    public float lowPitchRange = .5f;
    public float highPitchRange = 1.5f;

    // Use this for initialization
    void Awake () {
        SceneManager.activeSceneChanged += ChangeOfScene;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}
	
    public void PlaySingle(AudioClip clip)
    {
        _FxAudioSource.clip = clip;
        _FxAudioSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = UnityEngine.Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        _FxAudioSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        _FxAudioSource.clip = clips[randomIndex];

        //Play the clip.
        _FxAudioSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        if (volume > 1) { Debug.Log("Volume must be between 0.0 and 1.0"); return; }
        _MusicAudioSource.volume = volume;
    }

    public void SetEffectsVolume(float volume)
    {
        if (volume > 1) { Debug.Log("Volume must be between 0.0 and 1.0"); return; }
        if (_FxAudioSource.volume != volume)
        {
            _FxAudioSource.volume = volume;
            AudioClip aClip = Resources.Load<AudioClip>("Sound Assets/DogFX");
            SoundManager.instance.RandomizeSfx(aClip);
        }
    }

    void ChangeOfScene(Scene previous, Scene next)
    {
        if (instance != this) return;

        print(previous.name + " -> " + next.name);

        if (next.name.Equals("PlayScene"))
        {
            _MusicAudioSource.clip = PlayMusic;
            _MusicAudioSource.Stop();
            _MusicAudioSource.Play();
        }
        else if (_MusicAudioSource.clip.name.Equals("PlayMusic") && !next.name.Equals("PlayScene"))
        {
            _MusicAudioSource.clip = MenuMusic;
            _MusicAudioSource.Stop();
            _MusicAudioSource.Play();
        }
    }
}
