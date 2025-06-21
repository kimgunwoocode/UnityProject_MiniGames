using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    public Game2Manager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            manager.Score++;
            manager.ScoreText.text = manager.Score.ToString();
        }
    }
}
