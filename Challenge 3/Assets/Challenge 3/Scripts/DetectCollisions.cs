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
        Debug.Log("COLLISION");
    }
}