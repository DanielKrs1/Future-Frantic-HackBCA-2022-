using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public TimeMachine timeMachinePrefab;
    public GameObject gameOverScreen;
    public static bool gameOver;

    public static float timeSurvived;

    private void Awake() {
        gameOver = false;
        timeSurvived = 0f;
        Instantiate(timeMachinePrefab);
    }

    private void Update() {
        if (gameOver)
            return;

        timeSurvived += Time.deltaTime;
    }

    public static void GameOver() {
        gameOver = true;
        TimeMachine.Destroy();
        FindObjectOfType<EnemySpawner>().enabled = false;
        FindObjectOfType<GameManager>().Invoke("ShowGameOverScreen", 1.5f);
    }

    private void ShowGameOverScreen() {
        gameOverScreen.SetActive(true);
        GameObject.Find("Time Survived Text").GetComponent<TextMeshProUGUI>().text = "You Survived For: " + Mathf.Floor(timeSurvived) + " seconds";
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() {
        SceneManager.LoadScene("Main Menu");
    }
}