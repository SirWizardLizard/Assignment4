/*
 * Zechariah Burrus
 * Assignment 4
 * Handles player movement, audio and collisions. Prevents player from moving too high.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour {
    public bool gameOver;
    public bool isLowEnough;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start() {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update() {
        //if height is greater than 15 the balloon isn't low enough, force position to not be greater
        //and remove veloity so it isn't stuck
        if(transform.position.y >= 15) {
            isLowEnough = false;
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
            playerRb.velocity = Vector3.zero;
        } else {
            isLowEnough = true;
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough) {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnCollisionEnter(Collision other) {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb")) {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            gameOverText.SetActive(true);
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money")) {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        else if (other.gameObject.CompareTag("Ground")) {
            playerRb.AddForce((Vector3.up * 10), ForceMode.Impulse);
        }
    }

}
