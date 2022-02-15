using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject obstaclePrefab;
    private Vector3 spawnPoisition = new Vector3(25, 0, 0);

    private float startDelay = 2;
    private float repeatDelay = 2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start() {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    void SpawnObstacle() {
        if(playerControllerScript.gameOver == false) {
            Instantiate(obstaclePrefab, spawnPoisition, obstaclePrefab.transform.rotation);
        }
    }
}
