using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestroyerScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("BlockObstacle") || collision.gameObject.CompareTag("PointObstacle")) {
            Destroy(collision.gameObject);
        }
    }
}
