using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private void Awake()
    {
        Load_saveData();
    }

    public static void Load_saveData()
    {
        if (PlayerPrefs.HasKey("Game1MaxScore")) Game1Manager.Game1_MaxScore = PlayerPrefs.GetInt("Game1MaxScore");
        if (PlayerPrefs.HasKey("Game1MaxScoreDifficultly")) Game1Manager.Game1_MaxScore_Difficultly = PlayerPrefs.GetInt("Game1MaxScoreDifficultly");
        if (PlayerPrefs.HasKey("Game2MaxScore")) Game2Manager.Game2_MaxScore = PlayerPrefs.GetInt("Game2MaxScore");
        if (PlayerPrefs.HasKey("Game3MaxScore")) Game3Manager.Game3_MaxScore = PlayerPrefs.GetInt("Game3MaxScore");
        if (PlayerPrefs.HasKey("Game4MaxScore")) Game4Manager.Game4_MaxScore = PlayerPrefs.GetInt("Game4MaxScore");
    }

    public static void End_saveData()
    {
        PlayerPrefs.SetInt("Game1MaxScore", Game1Manager.Game1_MaxScore);
        PlayerPrefs.SetInt("Game1MaxScoreDifficultly", Game1Manager.Game1_MaxScore_Difficultly);
        PlayerPrefs.SetInt("Game2MaxScore", Game2Manager.Game2_MaxScore);
        PlayerPrefs.SetInt("Game3MaxScore", Game3Manager.Game3_MaxScore);
        PlayerPrefs.SetInt("Game4MaxScore", Game4Manager.Game4_MaxScore);
    }

    private void OnApplicationPause(bool pause)//강제 종료 시
    {
        if (pause)
        {
            End_saveData();
        }
    }
}
