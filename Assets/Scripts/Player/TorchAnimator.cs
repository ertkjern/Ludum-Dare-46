using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimator : MonoBehaviour
{

    private GameManager gameManger;
    private float timeLeft;
    private float maxTime;
    private Animator _animation;

    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<Animator>();
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        maxTime = gameManger.MaxTorchLife;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = gameManger.TorchLife;

        float timeLeftPercentage = timeLeft / maxTime;

        _animation.SetFloat("percentageLeft", timeLeftPercentage);
    }
}
