using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Start Map");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}