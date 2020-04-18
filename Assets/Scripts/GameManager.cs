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
}
