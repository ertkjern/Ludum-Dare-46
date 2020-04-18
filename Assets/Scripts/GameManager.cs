using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;
    public float maxTorchLife = 30.0f;
    public float torchLife = 30.0f;

    private void Update()
    {
        TorchLifeHandler();
    }

    public void TorchLifeHandler()
    {
        if (TorchLife > 0)
        {
            TorchLife -= Time.deltaTime;
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
}
