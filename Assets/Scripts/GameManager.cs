using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;

    public bool IsPaused
    {
        get { return isPaused;  }
        set { isPaused = value; }
    }
}
