using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour {

    public UIControllerScript uiControllerScript;
    public AudioControllerScript AudioControllerScript;

    public GameObject particleDestructionObject;
    public float destructionDuration = 0.8f;

    public float leftLane;
    public float rightLane;
    public float rotationDuration = 0.1f;
    public float movementDuration = 0.2f;
    public float rotationDegree = 25f;

    public float carSpeed = 10f;

    public void ChangeLane() {
        if (transform.position.x == leftLane) {
            transform.DOMoveX(rightLane, movementDuration).OnStart(RotateCarRight).OnComplete(StopRotation);
        } else if (transform.position.x == rightLane) {
            transform.DOMoveX(leftLane, movementDuration).OnStart(RotateCarLeft).OnComplete(StopRotation);
        }
    }

    void StopRotation() {
        transform.DORotate(new Vector3(0, 0, 0), rotationDuration);
    }

    void RotateCarLeft() {
        transform.DORotate(new Vector3(0, 0, rotationDegree), rotationDuration);
    }

    void RotateCarRight() {
        transform.DORotate(new Vector3(0, 0, -rotationDegree), rotationDuration);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("PointObstacle")) {
            Destroy(collision.gameObject);
            GameStatusScripts.currentScore++;
            AudioControllerScript.playReceivePointAudio();
        } else if (collision.gameObject.CompareTag("BlockObstacle")) {
            AudioControllerScript.playGameOverAudio();
            StartCoroutine(DestroyObstacle(collision.gameObject));
        }
    }

    IEnumerator DestroyObstacle(GameObject targetGameObject) {
        GameStatusScripts.gameRunning = false;
        targetGameObject.SetActive(false);
        GameObject destructionGameObject = Instantiate(particleDestructionObject, 
               targetGameObject.transform.position, targetGameObject.transform.rotation);
        yield return new WaitForSeconds(destructionDuration);
        Destroy(destructionGameObject);
        uiControllerScript.LoseGame();
    }
}
