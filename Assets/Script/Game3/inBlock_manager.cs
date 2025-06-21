using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inBlock_manager : MonoBehaviour
{
    public GameObject[] Number = new GameObject[14];

    public int this_num;

    public int this_position_num = 0;
    public int front_this_position_num = 0;

    private void Start()
    {
        int n = Random.Range(0, 10);

        if (n == 0)
            this_num = 2;
        else
            this_num = 1;

        Change_Number();
    }

    private void Update()
    {
        if (this_position_num != front_this_position_num)
        {
            switch (this_position_num)
            {

                case 0:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-3, 3, -1)/*, 10f)*/;
                        break;
                    }
                case 1:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-1, 3, -1)/*, 10f)*/;
                        break;
                    }
                case 2:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(1, 3, -1)/*, 10f)*/;
                        break;
                    }
                case 3:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(3, 3, -1)/*, 10f)*/;
                        break;
                    }
                case 4:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-3, 1, -1)/*, 10f)*/;
                        break;
                    }
                case 5:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-1, 1, -1)/*, 10f)*/;
                        break;
                    }
                case 6:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(1, 1, -1)/*, 10f)*/;
                        break;
                    }
                case 7:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(3, 1, -1)/*, 10f)*/;
                        break;
                    }
                case 8:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-3, -1, -1)/*, 10f)*/;
                        break;
                    }
                case 9:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-1, -1, -1)/*, 10f)*/;
                        break;
                    }
                case 10:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(1, -1, -1)/*, 10f)*/;
                        break;
                    }
                case 11:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(3, -1, -1)/*, 10f)*/;
                        break;
                    }
                case 12:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-3, -3, -1)/*, 10f)*/;
                        break;
                    }
                case 13:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(-1, -3, -1)/*, 10f)*/;
                        break;
                    }
                case 14:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(1, -3, -1)/*, 10f)*/;
                        break;
                    }
                case 15:
                    {
                        gameObject.transform.position = /*Vector3.MoveTowards(gameObject.transform.position, */new Vector3(3, -3, -1)/*, 10f)*/;
                        break;
                    }
            }

            front_this_position_num = this_position_num;
            Change_Number();
        }
    }

    void Change_Number()
    {
        if (this_num != 1)
            Number[this_num - 1].SetActive(false);

        Number[this_num].SetActive(true);
    }

}
