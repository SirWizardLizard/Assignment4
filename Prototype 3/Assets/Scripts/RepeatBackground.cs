using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start() {
        //Saves the starting position of the background
        startPosition = transform.position;

        //Set's the repeat width to half the width of the backgrounds box collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update() {
        //If the background is further to the left than repeatWidth we reset it to it's starting position
        if(transform.position.x <  startPosition.x - repeatWidth) {
            transform.position = startPosition;
        }
    }
}
