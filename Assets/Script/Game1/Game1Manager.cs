using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game1Manager : MonoBehaviour
{
    public GameObject startbutton;
    public Button UP;
    public Button DOWN;
    public Text Difficultly_Text;
    public Text ScoreText;
    public Text TimeText;
    public Text MaxScore;

    public GameObject[] gameButton = new GameObject[4];

    public GameObject Block_parent;
    public GameObject Block_MainParent;
    public GameObject Block_prefab;
    private Queue<int> Block = new Queue<int>(4);
    private Queue<GameObject> Block_obj = new Queue<GameObject>(4);

    public static int Game1_MaxScore;
    public static int Game1_MaxScore_Difficultly;
    public int Score;//현재 점수
    public int difficultly = 0;//난이도

    private int ButtonNumber = 2;//난이도에 따른 버튼 개수 : 2, 3, 4 개
    float time_ = 10;

    GameObject MainBlock;//메인으로 나와있는 block


    private void Awake()
    {
        ChangeDifficultly();
        MaxScore.text = "Max Score : " + Game1_MaxScore.ToString() + "  (" + Game1_MaxScore_Difficultly.ToString() + ")";
    }

    public void UP_Difficultly()
    {
        if (difficultly < 2)
            difficultly++;

        if (difficultly == 2)
            UP.interactable = false;

        DOWN.interactable = true;
    }

    public void DOWN_Difficultly()
    {
        if (difficultly > 0)
            difficultly--;

        if (difficultly == 0)
            DOWN.interactable = false;

        UP.interactable = true;
    }

    public void ChangeDifficultly()
    {
        switch (difficultly)
        {
            case 0:
                {
                    ButtonNumber = 2;
                    gameButton[0].SetActive(true);
                    gameButton[1].SetActive(true);
                    gameButton[2].SetActive(false);
                    gameButton[3].SetActive(false);
                    Difficultly_Text.text = "Easy";
                    break;
                }
            case 1:
                {
                    ButtonNumber = 3;
                    gameButton[0].SetActive(true);
                    gameButton[1].SetActive(true);
                    gameButton[2].SetActive(true);
                    gameButton[3].SetActive(false);
                    Difficultly_Text.text = "Normal";
                    break;
                }
            case 2:
                {
                    ButtonNumber = 4;
                    gameButton[0].SetActive(true);
                    gameButton[1].SetActive(true);
                    gameButton[2].SetActive(true);
                    gameButton[3].SetActive(true);
                    Difficultly_Text.text = "Hard";
                    break;
                }
        }
    }

    public void GameStart()
    {
        startbutton.SetActive(false);

        UP.interactable = false;
        DOWN.interactable = false;

        FirstStart();
    }

    public void GameEnd()
    {
        TimeText.text = "0.00";
        Destroy(MainBlock);
        Block.Clear();
        Destroy(Block_parent.transform.GetChild(3).gameObject);
        Destroy(Block_parent.transform.GetChild(2).gameObject);
        Destroy(Block_parent.transform.GetChild(1).gameObject);
        Destroy(Block_parent.transform.GetChild(0).gameObject);
        Block_obj.Clear();
        startbutton.SetActive(true);
        UP.interactable = true;
        DOWN.interactable = true;

        if (Score > Game1_MaxScore)
        {
            Game1_MaxScore = Score;
            Game1_MaxScore_Difficultly = difficultly;
        }
        Data.End_saveData();
        MaxScore.text = "Max Score : " + Game1_MaxScore.ToString() + "  (" + Game1_MaxScore_Difficultly.ToString() + ")";
    }

    void FirstStart()
    {

        for (int i = 0; i <= 4; i++)
        {
            NextBlock();
        }

        MainBlock = Block_obj.Dequeue();
        MainBlock.transform.SetParent(Block_MainParent.transform);
        MainBlock.transform.position = Block_MainParent.transform.position;

        time_ = 10f;
        Score = 0;

        StartCoroutine(CoolTime());
    }

    void NextBlock()
    {
        int first_color;

        first_color = Random.Range(1, ButtonNumber + 1);

        switch (first_color)
        {
            case 1:
                {
                    GameObject copyobj = Instantiate(Block_prefab);
                    copyobj.transform.SetParent(Block_parent.transform);
                    copyobj.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.red;
                    Block_obj.Enqueue(copyobj);
                    Block.Enqueue(1);
                    break;
                }
            case 2:
                {
                    GameObject copyobj = Instantiate(Block_prefab);
                    copyobj.transform.SetParent(Block_parent.transform);
                    copyobj.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.blue;
                    Block_obj.Enqueue(copyobj);
                    Block.Enqueue(2);
                    break;
                }
            case 3:
                {
                    GameObject copyobj = Instantiate(Block_prefab);
                    copyobj.transform.SetParent(Block_parent.transform);
                    copyobj.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
                    Block_obj.Enqueue(copyobj);
                    Block.Enqueue(3);
                    break;
                }
            case 4:
                {
                    GameObject copyobj = Instantiate(Block_prefab);
                    copyobj.transform.SetParent(Block_parent.transform);
                    copyobj.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.yellow;
                    Block_obj.Enqueue(copyobj);
                    Block.Enqueue(4);
                    break;
                }
        }
    }

    public void Button1_red()
    {
        if (Block.Peek() == 1)
        {
            time_ += Time.deltaTime * 0.2f;
            Score++;
            Block.Dequeue();
            Destroy(MainBlock);
            MainBlock = Block_obj.Dequeue();
            MainBlock.transform.SetParent(Block_MainParent.transform);
            MainBlock.transform.position = Block_MainParent.transform.position;

            NextBlock();
        }
        else
        {
            time_ -= Time.deltaTime * 0.5f;
            Handheld.Vibrate();
        }
    }

    public void Button2_blue()
    {
        if (Block.Peek() == 2)
        {
            time_ += Time.deltaTime * 0.2f;
            Score++;
            Block.Dequeue();
            Destroy(MainBlock);
            MainBlock = Block_obj.Dequeue();
            MainBlock.transform.SetParent(Block_MainParent.transform);
            MainBlock.transform.position = Block_MainParent.transform.position;

            NextBlock();
        }
        else
        {
            time_ -= Time.deltaTime * 0.5f;
            Handheld.Vibrate();
        }
    }

    public void Button3_green()
    {
        if (Block.Peek() == 3)
        {
            time_ += Time.deltaTime * 0.2f;
            Score++;
            Block.Dequeue();
            Destroy(MainBlock);
            MainBlock = Block_obj.Dequeue();
            MainBlock.transform.SetParent(Block_MainParent.transform);
            MainBlock.transform.position = Block_MainParent.transform.position;

            NextBlock();
        }
        else
        {
            time_ -= Time.deltaTime * 0.5f;
            Handheld.Vibrate();
        }
    }

    public void Button4_yellow()
    {
        if (Block.Peek() == 4)
        {
            time_ += Time.deltaTime * 0.2f;
            Score++;
            Block.Dequeue();
            Destroy(MainBlock);
            MainBlock = Block_obj.Dequeue();
            MainBlock.transform.SetParent(Block_MainParent.transform);
            MainBlock.transform.position = Block_MainParent.transform.position;

            NextBlock();
        }
        else
        {
            time_ -= Time.deltaTime * 0.5f;
            Handheld.Vibrate();
        }
    }


    IEnumerator CoolTime()
    {        
        while (true)
        {
            TimeText.text = time_.ToString("F2");
            ScoreText.text = Score.ToString();
            time_ -= Time.deltaTime;

            if (time_ <= 0)
            {
                GameEnd();
                yield break;
            }
            yield return null;
        }
    }

    public void Back_GameList()
    {
        SceneManager.LoadScene("GameList");
    }
}
