using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Load the main game scene
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
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
