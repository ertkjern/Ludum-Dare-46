using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;
    public float maxTorchLife = 30.0f;
    public float torchLife = 30.0f;
    public int life = 3;
    public bool isGameOver = false;
    public int numberOfMatchBoxesToSpawn = 30;
    public int numberOfSpidersToSpawn = 100;

    public GameObject matchBox;
    public GameObject spider;

    public GameObject topBound;
    public GameObject bottomBound;
    public GameObject leftBound;
    public GameObject rightBound;

    private void Start()
    {
        SpawnItem(matchBox, numberOfMatchBoxesToSpawn);
        SpawnItem(spider, numberOfSpidersToSpawn);
    }

    private void Update()
    {
        TorchLifeHandler();
        CheckIfGameOver();
    }

    private void TorchLifeHandler()
    {
        if (TorchLife > 0)
        {
            TorchLife -= Time.deltaTime;
        }
    }

    private void CheckIfGameOver()
    {
        float timeLeftPercentage = torchLife / maxTorchLife;
        if(timeLeftPercentage <= 0 || life == 0)
        {
            isGameOver = true;
        }

    }

    private void SpawnItem(GameObject prefab, int amount)
    {
        float topBoundY = topBound.transform.position.y;
        float bottomBoundY = bottomBound.transform.position.y;
        float leftBoundX = leftBound.transform.position.x;
        float rightBoundX = rightBound.transform.position.x;

        for (int i = 0; i < amount; i++)
        {
            float randomX = Random.Range(leftBoundX, rightBoundX);
            float randomY = Random.Range(bottomBoundY, topBoundY);
            // Simple hack to avoid spiders to spawn near player
            if ((randomX > 3.0f || randomX < -3.0f) && (randomY > 3.0f || randomY < -3.0f))
            {
                Instantiate(prefab, new Vector2(randomX, randomY), transform.rotation);
            }
        }
    }

    public bool IsPaused
    {
        get { return isPaused;  }
        set { isPaused = value; }
    }

    public float MaxTorchLife
    {
        get { return maxTorchLife; }
    }

    public float TorchLife
    {
        get { return torchLife; }
        set { torchLife = value;  }
    }

    public bool IsGameOver
    {
        get { return isGameOver;  }
    }

    public int Life
    {
        get { return life;  }
        set { life = value;  }
    }
}
