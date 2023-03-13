using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton(){
        Application.Quit();
    }
}
