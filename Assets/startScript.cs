using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame(){
        SceneManager.LoadScene("level0");
    }
}
