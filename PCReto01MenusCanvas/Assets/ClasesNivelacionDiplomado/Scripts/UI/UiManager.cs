using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public string sceneName = "CanvasPlayMenu";


    public void ExitButtonPressed()
    {
        Debug.Log("Sali del juego");
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);

    }

    
}
