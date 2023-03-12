using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayLessons()
    {
        //SceneManager.LoadScene(1);
    }
}
