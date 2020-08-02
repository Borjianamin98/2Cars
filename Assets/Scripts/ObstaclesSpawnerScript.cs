using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnerScript : MonoBehaviour {

    public GameObject[] blueObstacles;
    public GameObject[] redObstacles;
    public Transform obstacleSpawnTransform;

    private static float trackLeftSide = 4.3f;
    private static float trackRightSide = 1.45f;

    public void StartSpawning() {
        StartCoroutine(spawnBlueObstacles());
        StartCoroutine(spawnRedObstacles());
    }

    public void StopSpawning() {
        StopAllCoroutines();
    }

    IEnumerator spawnBlueObstacles() {
        while (GameStatusScripts.gameRunning) {
            int type = Random.Range(0, 2);
            int side = Random.Range(0, 2);
            float positionX = side == 0 ? trackLeftSide : trackRightSide;
            Vector3 newObstaclePosition = new Vector3(positionX, obstacleSpawnTransform.position.y, obstacleSpawnTransform.position.z);

            GameObject newObstacle = Instantiate(blueObstacles[type], newObstaclePosition, obstacleSpawnTransform.rotation);
            newObstacle.transform.SetParent(obstacleSpawnTransform);
            yield return new WaitForSeconds(GameStatusScripts.gameDifficulty);
        }
        yield break;
    }

    IEnumerator spawnRedObstacles() {
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));

        while (GameStatusScripts.gameRunning) {
            int type = Random.Range(0, 2);
            int side = Random.Range(0, 2);
            float positionX = side == 0 ? -trackLeftSide : -trackRightSide;
            Vector3 newObstaclePosition = new Vector3(positionX, obstacleSpawnTransform.position.y, obstacleSpawnTransform.position.z);

            GameObject newObstacle = Instantiate(redObstacles[type], newObstaclePosition, obstacleSpawnTransform.rotation);
            newObstacle.transform.SetParent(obstacleSpawnTransform);
            yield return new WaitForSeconds(GameStatusScripts.gameDifficulty);
        }
        yield break;
    }
    public void ClearObstacles() {
        foreach (Transform transform in obstacleSpawnTransform) {
            Destroy(transform.gameObject);
        }
    }
}
