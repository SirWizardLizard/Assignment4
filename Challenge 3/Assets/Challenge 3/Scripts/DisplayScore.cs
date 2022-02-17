/*
 * Zechariah Burrus
 * Assignment 2
 * Handles win condition and shows the score text
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour {
    public Text textbox;
    public int score = 0;

    public GameObject winText;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update() {
        textbox.text = "Score: " + score;
        if(score >= 30) {
            playerControllerScript.gameOver = true;
            winText.SetActive(true);
        }
    }
}