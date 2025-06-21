using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Game2 : MonoBehaviour
{
    public Game2Manager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "NotWall")
        {
            manager.GameOver();
        }
    }
}
