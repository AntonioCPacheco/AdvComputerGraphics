using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardTimer : MonoBehaviour {

    public int _MatchLength = 60;

    const string _Display = "{0} {1} : {2} {3}";
    private Text _Text;
    private bool timeRunout = false;

    // Use this for initialization
    void Start () {
        _Text = GetComponent<Text>();
        formatTime(_MatchLength);
    }
	
	// Update is called once per frame
	void Update () {
        int secondsLeft = _MatchLength - (int)Time.timeSinceLevelLoad;
        formatTime(secondsLeft);

        if (HasTimeRunout() && !timeRunout)
        {
            timeRunout = true;
            FindObjectOfType<GameManager>().GameOver(this.transform);
        }
    }

    private void formatTime(int secs)
    {
        int _Minutes = secs / 60;
        int _Seconds = secs % 60;

        int first_digit = _Minutes / 10;
        int second_digit = _Minutes % 10;
        int third_digit = _Seconds / 10;
        int fourth_digit = _Seconds % 10;

        _Text.text = string.Format(_Display, first_digit, second_digit, third_digit, fourth_digit);
    }

    public bool HasTimeRunout()
    {
        int secondsLeft = _MatchLength - (int)Time.timeSinceLevelLoad;
        return (secondsLeft <= 0);
    }
}
