using System.Collections;
using UnityEngine;

public class ObstaclesEndLineScript : MonoBehaviour {

    public UIControllerScript uiControllerScript;
    public AudioControllerScript AudioControllerScript;
    public float blinkingDuration = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PointObstacle")) {
            AudioControllerScript.playGameOverAudio();
            GameStatusScripts.gameRunning = false;
            StartCoroutine(BlinkObstacle(collision.gameObject, blinkingDuration));
        }
    }

    IEnumerator BlinkObstacle(GameObject targetGameObject, float duration) {
        var endTime = Time.time + duration;
        Renderer tagetRenderer = targetGameObject.GetComponent<Renderer>();
        while (Time.time < endTime) {
            tagetRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            tagetRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        tagetRenderer.enabled = true;
        uiControllerScript.LoseGame();
    }
}
