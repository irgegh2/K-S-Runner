using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
