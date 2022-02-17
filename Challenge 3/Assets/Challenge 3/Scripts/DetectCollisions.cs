/*
 * Zechariah Burrus
 * Assignment 4
 * Inrements score whenever the gameobject has a collision
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour {
    private DisplayScore displayScoreScript;

    private void Start() {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnCollisionEnter(Collision other) {
        displayScoreScript.score++;
    }
}