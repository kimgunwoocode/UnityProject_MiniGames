using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1ListManager : MonoBehaviour
{
    public Text ScoreText1;
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;

    private void LateUpdate()
    {
        ScoreText1.text = Game1Manager.Game1_MaxScore.ToString();
        ScoreText2.text = Game2Manager.Game2_MaxScore.ToString();
        ScoreText3.text = Game3Manager.Game3_MaxScore.ToString();
        ScoreText3.text = Game4Manager.Game4_MaxScore.ToString();
    }
}
