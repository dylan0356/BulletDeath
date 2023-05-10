using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour {

    public static int scoreVal = 0; // initiates a score integer variable set to 0
    public GameObject scoreUI; // string UI

    TextMeshProUGUI scoreTextUI; // string UI

    void Start(){
        scoreTextUI = scoreUI.GetComponent<TextMeshProUGUI>(); // gets the score UI component

    }

    void Update() {
        scoreTextUI.text = "Score: " + scoreVal; // updates the score UI

    }

    public static void AddScore(int score) {
        scoreVal += score; // adds score to the scoreVal variable
    }

    public static void ResetScore() {
        scoreVal = 0; // resets the scoreVal variable to 0
    }
}