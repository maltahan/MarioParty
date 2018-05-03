using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    // Use this for initialization
    public static int ScoreValue = 0;
    Text Score;
	void Start () {
        Score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Score.text = "Score" + ScoreValue;
	}
}
