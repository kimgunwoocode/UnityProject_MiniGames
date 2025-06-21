using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2Manager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject StartButton;
    public Text ScoreText;
    public Text MaxScoreText;

    public GameObject Wall_parent;

    public GameObject floor;
    public GameObject Player;
    public Rigidbody2D Player_Rigidbody;

    public GameObject[] Game2Wall = new GameObject[6];

    public static int Game2_MaxScore = 0;
    public int Score;

    private float Touch_y;

    public void GameStart()
    {
        StartButton.SetActive(false);

        Player_Rigidbody.gravityScale = 2;
        StartCoroutine("Game");
    }

    public void GameOver()
    {
        StopCoroutine("Game");
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("Game2Wall"))
        {
            Destroy(game);
        }
        Player.transform.position = new Vector2(-5, 0);
        Player_Rigidbody.velocity = Vector2.zero;
        Player_Rigidbody.gravityScale = 0;
        StartButton.SetActive(true);

        ScoreText.text = "0";

        if (Score > Game2_MaxScore)
        {
            Game2_MaxScore = Score;
            MaxScoreText.text = "Max Score : " + Game2_MaxScore.ToString();
        }
        Score = 0;
    }

    public void Start()
    {
        Player_Rigidbody.gravityScale = 0;
    }

    IEnumerator Game()
    {
        float Walltime = 1.5f;

        while (true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Player_Rigidbody.velocity = new Vector2(0, 7.3f);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player_Rigidbody.velocity = new Vector2(0, 7.3f);
            }

            if (Walltime <= 0)
            {
                Instantiate_Game2Wall();
                Walltime = 1.7f;
            }
            else
            {
                Walltime -= Time.deltaTime;
            }

            yield return null;
        }
    }

    void Instantiate_Game2Wall()
    {
        int rand = Random.Range(0, 6);

        GameObject Wall = Instantiate(Game2Wall[rand], Wall_parent.transform);
        Wall.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
    }

    public void BackScreen()
    {
        SceneManager.LoadScene("GameList");
    }
}
