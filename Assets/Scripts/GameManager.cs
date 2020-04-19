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
    public int numberOfMatchBoxesToSpawn;
    public int numberOfSpidersToSpawn;
    public bool isVictory = false;
    public float distanceToGoal;

    public GameObject matchBox;
    public GameObject spider;
    public GameObject choppa;

    public GameObject topBound;
    public GameObject bottomBound;
    public GameObject leftBound;
    public GameObject rightBound;

    private void Start()
    {
        SpawnItem(matchBox, numberOfMatchBoxesToSpawn, 3.5f);
        SpawnItem(spider, numberOfSpidersToSpawn, 3.5f);
        SpawnItem(choppa, 1, 16.0f); // Spawn Win
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

    private void SpawnItem(GameObject prefab, int amount, float minDistance)
    {
        float topBoundY = topBound.transform.position.y;
        float bottomBoundY = bottomBound.transform.position.y;
        float leftBoundX = leftBound.transform.position.x;
        float rightBoundX = rightBound.transform.position.x;

        for (int i = 0; i < amount; i++)
        {
            bool hasSpawned = false;
            // make sure all objects are spawned.
            while (!hasSpawned)
            {
                float randomX = Random.Range(leftBoundX, rightBoundX);
                float randomY = Random.Range(bottomBoundY, topBoundY);
                // Simple hack to avoid spiders to spawn near player
                if ((randomX > minDistance || randomX < -minDistance) && (randomY > minDistance || randomY < -minDistance))
                {
                    Instantiate(prefab, new Vector2(randomX, randomY), transform.rotation);
                    hasSpawned = true;
                }
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

    public bool IsVictory
    {
        get { return isVictory; }
        set { isVictory = value; }
    }

    public float DistanceToGoal
    {
        get { return distanceToGoal; }
        set { distanceToGoal = value; }
    }
}
