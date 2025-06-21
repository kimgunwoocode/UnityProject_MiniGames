using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game3Manager : MonoBehaviour
{
    public Text ScoreText;
    public Text MaxScoreText;
    public GameObject StartButton;

    public GameObject BackGameScreen;
    public GameObject Block_obj;

    public GameObject Null;
    private void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            Block_position[i] = Null;
        }
    }

    public static int Game3_MaxScore;

    private bool Move_fin = true;
    public enum Move_pos { Idle, UP, DOWN, LEFT, RIGHT };
    public Move_pos Move_ = Move_pos.Idle;

    [SerializeField]
    private GameObject[] Block_position = new GameObject[16];

    public void BackScreen()
    {
        SceneManager.LoadScene("GameList");
    }

    public void GameStart()
    {
        StartButton.SetActive(false);
        Block_position[0] = Instantiate(Block_obj);
        Block_position[0].transform.SetParent(BackGameScreen.transform);
        Block_position[0].transform.position = new Vector3(-3, 3, -1);
        StartCoroutine("MainGame");
    }

    public void GameOver()
    {


        StartButton.SetActive(true);
    }

    private Vector2 nowPos, prePos;
    private Vector2 movePos;
    IEnumerator MainGame()
    {
        while (true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && Move_fin)
                {
                    prePos = touch.position - touch.deltaPosition;
                    Move_fin = false;
                }
                else if (touch.phase == TouchPhase.Moved && Move_ == Move_pos.Idle)
                {
                    nowPos = touch.position - touch.deltaPosition;
                    movePos = (prePos - nowPos);
                    if (movePos.sqrMagnitude >= 5000)
                    {
                        if (Mathf.Abs(movePos.y) >= Mathf.Abs(movePos.x))
                        {
                            if (movePos.y < 0)
                            {
                                Move_ = Move_pos.UP;
                            }
                            else if (movePos.y > 0)
                            {
                                Move_ = Move_pos.DOWN;
                            }
                        }
                        else if (Mathf.Abs(movePos.y) < Mathf.Abs(movePos.x))
                        {
                            if (movePos.x < 0)
                            {
                                Move_ = Move_pos.RIGHT;
                            }
                            else if (movePos.x > 0)
                            {
                                Move_ = Move_pos.LEFT;
                            }
                        }
                    }

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Move_fin = true;
                }
            }

            if (Move_ == Move_pos.Idle)
            {
                if (Input.GetKeyDown(KeyCode.W))
                    Move_ = Move_pos.UP;
                else if (Input.GetKeyDown(KeyCode.S))
                    Move_ = Move_pos.DOWN;
                else if (Input.GetKeyDown(KeyCode.A))
                    Move_ = Move_pos.LEFT;
                else if (Input.GetKeyDown(KeyCode.D))
                    Move_ = Move_pos.RIGHT;
            }


            if (Move_ != Move_pos.Idle)
            {
                print(Move_);

                Move_Set_Block();
                yield return new WaitForSeconds(0.2f);
                Move_ = Move_pos.Idle;
            }


            yield return null;
        }

    }

    void Move_Set_Block()
    {
        List<int> Null_num = new List<int>();
        int pos_ = 0;
        switch(Move_)
        {
            case Move_pos.UP:
                pos_ = 1; break;
            case Move_pos.DOWN:
                pos_ = 2; break;
            case Move_pos.LEFT:
                pos_ = 3; break;
            case Move_pos.RIGHT:
                pos_ = 4; break;
        }

        BlockPush(1, pos_);
        BlockPush(2, pos_);
        BlockPush(3, pos_);
        BlockPush(4, pos_);

        for (int i = 0; i < 16; i++)
        {
            if (Block_position[i].tag != "Game3Block")
            {
                Null_num.Add(i);
            }
        }

        int n = Random.Range(0, Null_num.Count);

        Block_position[Null_num[n]] = Instantiate(Block_obj);
        Block_position[Null_num[n]].transform.SetParent(BackGameScreen.transform);

        switch (Null_num[n])
        {

            case 0:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-3, 3, -1);
                    break;
                }
            case 1:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-1, 3, -1);
                    break;
                }
            case 2:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(1, 3, -1);
                    break;
                }
            case 3:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(3, 3, -1);
                    break;
                }
            case 4:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-3, 1, -1);
                    break;
                }
            case 5:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-1, 1, -1);
                    break;
                }
            case 6:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(1, 1, -1);
                    break;
                }
            case 7:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(3, 1, -1);
                    break;
                }
            case 8:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-3, -1, -1);
                    break;
                }
            case 9:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-1, -1, -1);
                    break;
                }
            case 10:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(1, -1, -1);
                    break;
                }
            case 11:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(3, -1, -1);
                    break;
                }
            case 12:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-3, -3, -1);
                    break;
                }
            case 13:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(-1, -3, -1);
                    break;
                }
            case 14:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(1, -3, -1);
                    break;
                }
            case 15:
                {
                    Block_position[Null_num[n]].transform.position = new Vector3(3, -3, -1);
                    break;
                }
        }

    }

    void BlockPush(int Num, int forward)//Num : 행 또는 열 선택, 1 ~ 4
    {
        switch(forward)
        {
            case 1:
                {
                    for (int I = 1; I <= 3; I++)
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            if (Block_position[Num - 1 + (4 * i)].tag == "Game3Block")
                            {
                                if (Block_position[Num - 1 + (4 * (i - 1))].tag == "Game3Block")
                                {
                                    if (Block_position[Num - 1 + (4 * (i - 1))].GetComponent<inBlock_manager>().this_num == Block_position[Num - 1 + (4 * i)].GetComponent<inBlock_manager>().this_num)
                                    {
                                        Block_position[Num - 1 + (4 * (i - 1))].GetComponent<inBlock_manager>().this_num -= 4;
                                        Destroy(Block_position[Num - 1 + (4 * i)]);
                                        Block_position[Num - 1 + (4 * i)] = Null;
                                        print("sum up");
                                        print(Num - 1 + (4 * (i - 1)));
                                    }
                                }
                                else
                                {
                                    Block_position[Num - 1 + (4 * (i - 1))] = Block_position[Num - 1 + (4 * i)];
                                    Block_position[Num - 1 + (4 * i)] = Null;
                                    Block_position[Num - 1 + (4 * (i - 1))].GetComponent<inBlock_manager>().this_position_num -= 4;
                                    print("move up");
                                    print(Num - 1 + (4 * (i - 1)));
                                }
                            }
                        }
                    }
                    break;
                }
            case 2:
                {
                    for (int I = 1; I <= 3; I++)
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (Block_position[Num - 1 + (4 * i)].tag == "Game3Block")
                            {
                                if (Block_position[Num - 1 + (4 * (i + 1))].tag == "Game3Block")
                                {
                                    if (Block_position[Num - 1 + (4 * (i + 1))].GetComponent<inBlock_manager>().this_num == Block_position[Num - 1 + (4 * i)].GetComponent<inBlock_manager>().this_num)
                                    {
                                        Block_position[Num - 1 + (4 * (i + 1))].GetComponent<inBlock_manager>().this_num += 4;
                                        Destroy(Block_position[Num - 1 + (4 * i)]);
                                        Block_position[Num - 1 + (4 * i)] = Null;
                                        print("sum down");
                                        print(Num - 1 + (4 * (i + 1)));
                                    }
                                }
                                else
                                {
                                    Block_position[Num - 1 + (4 * (i + 1))] = Block_position[Num - 1 + (4 * i)];
                                    Block_position[Num - 1 + (4 * i)] = Null;
                                    Block_position[Num - 1 + (4 * (i + 1))].GetComponent<inBlock_manager>().this_position_num += 4;
                                    print("move down");
                                    print(Num - 1 + (4 * (i + 1)));
                                }
                            }
                        }
                    }
                    break;
                }
            case 3:
                {
                    for (int I = 1; I <= 3; I++)
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            if (Block_position[Num - 1 + i].tag == "Game3Block")
                            {
                                if (Block_position[Num - 1 + (i - 1)].tag == "Game3Block")
                                {
                                    if (Block_position[Num - 1 + (i - 1)].GetComponent<inBlock_manager>().this_num == Block_position[Num - 1 + i].GetComponent<inBlock_manager>().this_num)
                                    {
                                        Block_position[Num - 1 + (i - 1)].GetComponent<inBlock_manager>().this_num++;
                                        Destroy(Block_position[Num - 1 + i]);
                                        Block_position[Num - 1 + i] = Null;
                                        print("sum left");
                                        print(Num - 1 + (i - 1));
                                    }
                                }
                                else
                                {
                                    Block_position[Num - 1 + (i - 1)] = Block_position[Num - 1 + i];
                                    Block_position[Num - 1 + i] = Null;
                                    Block_position[Num - 1 + (i - 1)].GetComponent<inBlock_manager>().this_position_num--;
                                    print("move left");
                                    print(Num - 1 + (i - 1));
                                }
                            }
                        }
                    }
                    break;
                }
            case 4:
                {
                    for (int I = 1; I <= 3; I++)
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (Block_position[Num - 1 + i].tag == "Game3Block")
                            {
                                if (Block_position[Num - 1 + (i + 1)].tag == "Game3Block")
                                {
                                    if (Block_position[Num - 1 + (i + 1)].GetComponent<inBlock_manager>().this_num == Block_position[Num - 1 + i].GetComponent<inBlock_manager>().this_num)
                                    {
                                        Block_position[Num - 1 + (i + 1)].GetComponent<inBlock_manager>().this_num++;
                                        Destroy(Block_position[Num - 1 + i]);
                                        Block_position[Num - 1 + i] = Null;
                                        print("sum right");
                                        print(Num - 1 + (i + 1));
                                    }
                                }
                                else
                                {
                                    Block_position[Num - 1 + (i + 1)] = Block_position[Num - 1 + i];
                                    Block_position[Num - 1 + i] = Null;
                                    Block_position[Num - 1 + (i + 1)].GetComponent<inBlock_manager>().this_position_num++;
                                    print("move right");
                                    print(Num - 1 + (i + 1));
                                }
                            }
                        }
                    }
                    break;
                }
        }



   }

    /*
    private Vector2 nowPos, prePos;
    private Vector2 movePos;
    IEnumerator MainGame_old()
    {
        while (true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && Move_fin)
                {
                    prePos = touch.position - touch.deltaPosition;
                    Move_fin = false;
                }
                else if (touch.phase == TouchPhase.Moved && Move_ == Move_pos.Idle)
                {
                    nowPos = touch.position - touch.deltaPosition;
                    movePos = (prePos - nowPos);
                    if (movePos.sqrMagnitude >= 5000)
                    {
                        if (Mathf.Abs(movePos.y) >= Mathf.Abs(movePos.x))
                        {
                            if (movePos.y < 0)
                            {
                                Move_ = Move_pos.UP;
                            }
                            else if (movePos.y > 0)
                            {
                                Move_ = Move_pos.DOWN;
                            }
                        }
                        else if (Mathf.Abs(movePos.y) < Mathf.Abs(movePos.x))
                        {
                            if (movePos.x < 0)
                            {
                                Move_ = Move_pos.RIGHT;
                            }
                            else if (movePos.x > 0)
                            {
                                Move_ = Move_pos.LEFT;
                            }
                        }
                    }

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Move_fin = true;
                }
            }

            if (Move_ == Move_pos.Idle)
            {
                if (Input.GetKeyDown(KeyCode.W))
                    Move_ = Move_pos.UP;
                else if (Input.GetKeyDown(KeyCode.S))
                    Move_ = Move_pos.DOWN;
                else if (Input.GetKeyDown(KeyCode.A))
                    Move_ = Move_pos.LEFT;
                else if (Input.GetKeyDown(KeyCode.D))
                    Move_ = Move_pos.RIGHT;
            }

            if (Move_ != Move_pos.Idle)
            {
                print(Move_);

                Block_Move();
                StartCoroutine("Block_Set");
            }


            yield return null;
        }
    }

    void Block_Move_old()
    {
        GameObject[] Blocks = GameObject.FindGameObjectsWithTag("Game3Block");

        switch (Move_)
        {
            case Move_pos.UP:
                {
                    foreach (GameObject obj in Blocks)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30);
                    }
                    break;
                }
            case Move_pos.DOWN:
                {
                    foreach (GameObject obj in Blocks)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -30);
                    }
                    break;
                }
            case Move_pos.LEFT:
                {
                    foreach (GameObject obj in Blocks)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
                    }
                    break;
                }
            case Move_pos.RIGHT:
                {
                    foreach (GameObject obj in Blocks)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);
                    }
                    break;
                }
        }
    }

    IEnumerator Block_Set_old()
    {
        yield return new WaitForSeconds(0.2f);

        if (Move_ != Move_pos.Idle)
        {
            GameObject copy = Instantiate(Block_obj);
            copy.transform.SetParent(BackGameScreen.transform);

            GameObject[] Blocks = GameObject.FindGameObjectsWithTag("Game3Block");

            foreach (GameObject obj in Blocks)
            {
                switch (obj.transform.position.x)
                {
                    case -3:
                        {
                            switch (obj.transform.position.y)
                            {
                                case -3:
                                    {
                                        Block_position[0] = true;
                                        break;
                                    }
                                case -1:
                                    {
                                        Block_position[1] = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        Block_position[2] = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        Block_position[3] = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case -1:
                        {
                            switch (obj.transform.position.y)
                            {
                                case -3:
                                    {
                                        Block_position[4] = true;
                                        break;
                                    }
                                case -1:
                                    {
                                        Block_position[5] = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        Block_position[6] = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        Block_position[7] = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 1:
                        {
                            switch (obj.transform.position.y)
                            {
                                case -3:
                                    {
                                        Block_position[8] = true;
                                        break;
                                    }
                                case -1:
                                    {
                                        Block_position[9] = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        Block_position[10] = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        Block_position[11] = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            switch (obj.transform.position.y)
                            {
                                case -3:
                                    {
                                        Block_position[12] = true;
                                        break;
                                    }
                                case -1:
                                    {
                                        Block_position[13] = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        Block_position[14] = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        Block_position[15] = true;
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }

            int count = 0;
            List<int> position_int = new List<int>();

            for (int i = 0; i < 16; i++)
            {
                if (Block_position[i])
                {
                    count++;
                    position_int.Add(i);
                }
            }

            int num = position_int[Random.Range(0, count)];

            switch (num)
            {
                case 0:
                    {
                        copy.transform.position = new Vector3(-3, -3, -1);
                        break;
                    }
                case 1:
                    {
                        copy.transform.position = new Vector3(-1, -3, -1);
                        break;
                    }
                case 2:
                    {
                        copy.transform.position = new Vector3(1, -3, -1);
                        break;
                    }
                case 3:
                    {
                        copy.transform.position = new Vector3(3, -3, -1);
                        break;
                    }
                case 4:
                    {
                        copy.transform.position = new Vector3(-3, -1, -1);
                        break;
                    }
                case 5:
                    {
                        copy.transform.position = new Vector3(-1, -1, -1);
                        break;
                    }
                case 6:
                    {
                        copy.transform.position = new Vector3(1, -1, -1);
                        break;
                    }
                case 7:
                    {
                        copy.transform.position = new Vector3(3, -1, -1);
                        break;
                    }
                case 8:
                    {
                        copy.transform.position = new Vector3(-3, 1, -1);
                        break;
                    }
                case 9:
                    {
                        copy.transform.position = new Vector3(-1, 1, -1);
                        break;
                    }
                case 10:
                    {
                        copy.transform.position = new Vector3(1, 1, -1);
                        break;
                    }
                case 11:
                    {
                        copy.transform.position = new Vector3(3, 1, -1);
                        break;
                    }
                case 12:
                    {
                        copy.transform.position = new Vector3(-3, -1, -1);
                        break;
                    }
                case 13:
                    {
                        copy.transform.position = new Vector3(-1, -1, -1);
                        break;
                    }
                case 14:
                    {
                        copy.transform.position = new Vector3(1, -1, -1);
                        break;
                    }
                case 15:
                    {
                        copy.transform.position = new Vector3(3, -1, -1);
                        break;
                    }
            }
        }
        Move_ = Move_pos.Idle;
        yield break;
    }
    */
}
