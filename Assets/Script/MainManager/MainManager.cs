using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{


    void Update()
    {
        
    }

    public void Open_GameListScreen()
    {
        SceneManager.LoadScene("GameList");
    }

    public void Open_HelpScreen()
    {

    }

    public void Exit()
    {

        Application.Quit();
    }
}
