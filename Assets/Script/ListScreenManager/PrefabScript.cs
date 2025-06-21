using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrefabScript : MonoBehaviour
{
    public Image MainImage;
    public Text Title;
    public Text MaxScore;
    public Button StartButton;
    public string SceneName;

    public void StartButton_NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
