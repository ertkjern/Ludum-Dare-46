using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject _player;
    private AudioSource audioSoruce;
    private float minChoperSoundDistance = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
        audioSoruce = GetComponent<AudioSource>();
        audioSoruce.volume = 0.0f; // turn of choppa sound
    }

    private void Update()
    {
        if (!gameManager.IsVictory || !gameManager.isGameOver || !gameManager.isPaused)
        {
            float distance = Vector2.Distance(_player.transform.position, transform.position);

            if (distance < minChoperSoundDistance)
            {
                float percentageClose = 100 - ((distance * 100) / minChoperSoundDistance);
                float normalizedDistance = percentageClose / 100;
                gameManager.DistanceToGoal = normalizedDistance;
                Debug.Log(normalizedDistance);
                // Super noicy. Try to turn down max volume a bit... 
                if (normalizedDistance > 0.3f)
                {
                    audioSoruce.volume = 0.3f;
                } else
                {
                    audioSoruce.volume = normalizedDistance;

                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            gameManager.IsVictory = true;
        }
    }
}

