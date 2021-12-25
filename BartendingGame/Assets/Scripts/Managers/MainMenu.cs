using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    public Button easy, normal, hard;

    public void Play()
    {
        // Reveal difficulty buttons
        RevealButtons();
    }

    private void RevealButtons()
    {
        easy.gameObject.SetActive(true);
        normal.gameObject.SetActive(true);
        hard.gameObject.SetActive(true);
    }

    public void LoadGame(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                {
                    difficultyManager.difficulty = DifficultyManager.Difficulty.easy;
                    SceneManager.LoadScene("SampleScene");
                }
                break;

            case "Normal":
                {
                    difficultyManager.difficulty = DifficultyManager.Difficulty.normal;
                    SceneManager.LoadScene("SampleScene");
                }
                break;

            case "Hard":
                {
                    difficultyManager.difficulty = DifficultyManager.Difficulty.hard;
                    SceneManager.LoadScene("SampleScene");
                }
                break;
        }
    }

    public void Settings()
    {
        // Load settings scene
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void Quit()
    {
        // Quit the game
        Application.Quit();
    }
}
