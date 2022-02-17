/*
 * Zechariah Burrus
 * Assignment 4
 * Handles the UI, displays score text and text on win/lose conditions. Also lets the player press R to restart.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    public int score = 0;
    public Text scoreText;

    public PlayerController playerControllerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start() {
        if(scoreText == null) {
            scoreText = FindObjectOfType<Text>();
        }

        if(playerControllerScript == null) {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update() {
        if (!playerControllerScript.gameOver) {
            scoreText.text = "Score: " + score;
        }

        if(playerControllerScript.gameOver && !won) {
            scoreText.text = "You Lose! \n Press R to Try Again!";
        }

        if(score >= 10) {
            playerControllerScript.gameOver = true;
            won = true;

            //Stop player from running

            scoreText.text = "You Win!\nPress R to Try Again!";
        }

        if(playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
