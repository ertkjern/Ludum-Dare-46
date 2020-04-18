using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBox : MonoBehaviour
{
    private float extraTime = 10.0f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            float currentTime = gameManager.TorchLife;
            if (currentTime + extraTime >= gameManager.MaxTorchLife)
            {
                gameManager.TorchLife = gameManager.MaxTorchLife;
            }
            else
            {
                gameManager.TorchLife += extraTime;
            }
            Destroy(this.gameObject);
        }
    }
}
