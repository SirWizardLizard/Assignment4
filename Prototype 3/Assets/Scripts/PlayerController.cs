/*
 * Zechariah Burrus
 * Assignment 4
 * handles sounds and animations for player as well as jumping movement.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { 
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode forceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start() {
        //grab the rigidbody
        rb = GetComponent<Rigidbody>();

        //get animator
        playerAnimator = GetComponent<Animator>();

        //Start running (Because speed is required to be 1 or greater for the running animation)
        playerAnimator.SetFloat("Speed_f", 1.0f);

        //set reference to audio source
        playerAudio = GetComponent<AudioSource>();

        forceMode = ForceMode.Impulse;

        if(Physics.gravity.y > -10) {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");

            //Stop dirt particles because player is in the air
            dirtParticle.Stop();

            //Jump sound effect
            playerAudio.PlayOneShot(jumpSound, 0.6f);
        }
    }

    //If the player collides
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground") && !gameOver) {
            isOnGround = true;

            //Play dirt particles because player landed
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle") && !gameOver) {
            Debug.Log("Game Over!");
            gameOver = true;

            //Death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //Play the explosition particle effect
            explosionParticle.Play();

            //Stop dirt particles because player is dead
            dirtParticle.Stop();

            //Collision sound effect
            playerAudio.PlayOneShot(crashSound, 0.6f);
        }
    }
}
