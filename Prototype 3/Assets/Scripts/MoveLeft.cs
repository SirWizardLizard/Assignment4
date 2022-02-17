/*
 * Zechariah Burrus
 * Assignment 4
 * Causes objets to move left while the game is not over. Destroys out of bounds objects.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    public float speed = 30f;
    public float leftBound = -15;

    private PlayerController playerControllerScript;

    void Start() {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        //Move left but check for gameOver Condition first
        if(playerControllerScript.gameOver == false) {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        //Destroy out of bounds object
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
