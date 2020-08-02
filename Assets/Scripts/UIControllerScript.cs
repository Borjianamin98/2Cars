using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject[] cars;
    public ObstaclesSpawnerScript obstaclesSpawnerScript;

    public Text inGameScore;
    public Text cellScoreValue;
    public Text cellBestScoreValue;

    private Vector3[] initialPositionOfCars;

    void Start() {
        initialPositionOfCars = new Vector3[cars.Length];
        for (int i = 0; i < cars.Length; i++) {
            initialPositionOfCars[i] = cars[i].transform.position;
        }
        if (SceneManager.GetActiveScene().name == "GameScene") {
            StartGame();
        }
    }

    private void Update() {
        if (GameStatusScripts.gameRunning) {
            GameStatusScripts.gameDifficulty -= Time.deltaTime * 0.001f;
            inGameScore.text = GameStatusScripts.currentScore.ToString();
        }
    }

    public void GoToGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToHomeScene() {
        SceneManager.LoadScene("HomeScene");
    }

    private void initializeGameBoard() {
        // Clear last game state
        GameStatusScripts.currentScore = 0;
        obstaclesSpawnerScript.ClearObstacles();
        for (int i = 0; i < cars.Length; i++) {
            cars[i].transform.position = initialPositionOfCars[i];
            cars[i].SetActive(true);
        }
        GameStatusScripts.gameDifficulty = 1.0f;
    }

    public void StartGame() {
        initializeGameBoard();

        // Start new game
        GameStatusScripts.gameRunning = true;
        obstaclesSpawnerScript.StartSpawning();
    }

    public void ReloadGame() {
        initializeGameBoard();

        // Start new game
        GameStatusScripts.gameRunning = true;
        obstaclesSpawnerScript.StartSpawning();
        gameOverMenu.SetActive(false);
    }

    public void PauseGame() {
        GameStatusScripts.gameRunning = false;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        GameStatusScripts.gameRunning = true;
        obstaclesSpawnerScript.StartSpawning();
        pauseMenu.SetActive(false);
    }

    public void LoseGame() {
        GameStatusScripts.gameRunning = false;
        gameOverMenu.SetActive(true);
        obstaclesSpawnerScript.StopSpawning();
        GameStatusScripts.bestScore = Mathf.Max(GameStatusScripts.bestScore, GameStatusScripts.currentScore);

        cellScoreValue.text = GameStatusScripts.currentScore.ToString();
        cellBestScoreValue.text = GameStatusScripts.bestScore.ToString();
    }
}
