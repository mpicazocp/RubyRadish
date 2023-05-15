using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("InfoScene");
    }

    public void QuitGame(){
        SceneManager.LoadScene("Credits");
    }

    public void GoToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevel0(){
        SceneManager.LoadScene("level0");
    }

}

