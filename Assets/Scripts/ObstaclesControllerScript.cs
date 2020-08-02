using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControllerScript : MonoBehaviour {

    public float speed = 10f;

    void Update() {
        if (GameStatusScripts.gameRunning) {
            transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        }
    }
}
