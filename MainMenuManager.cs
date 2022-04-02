using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject howToPlayMenu;
    public GameObject creditsScreen;

    public void StartGame() {
        SceneManager.LoadScene("Game Scene");
    }

    public void ShowRules() {
        mainMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
    }

    public void BackToMainMenu() {
        howToPlayMenu.SetActive(false);
        creditsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowCredits() {
        mainMenu.SetActive(false);
        creditsScreen.SetActive(true);
    }
}