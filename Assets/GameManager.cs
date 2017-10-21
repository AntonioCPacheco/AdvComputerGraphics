using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject _GameOverScreen;

    // Use this for initialization
    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Play()
    {
        ResumeTime();
        SceneManager.LoadScene("PlayScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver(Transform loser)
    {
        StopTime();
        _GameOverScreen.GetComponent<GameOverScreenManager>().SetActive(true);
        _GameOverScreen.GetComponent<GameOverScreenManager>().SetWinner(loser);
    }

    public static void StopTime()
    {
        print("STOP");
        Time.timeScale = 0;
    }

    public static void ResumeTime()
    {
        Time.timeScale = 1;
    }

    public static void SlowTime()
    {
        Time.timeScale = 0.3f;
    }
}
