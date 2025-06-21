using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListManager : MonoBehaviour
{
    public void Back_MainScreen()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
