using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Image image;
    private GameManager gameManger;
    private float timeLeft;
    private float maxTime;

    // Colors
    public Color high;
    public Color medium;
    public Color low;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        maxTime = gameManger.MaxTorchLife;
        image.color = high;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = gameManger.TorchLife;
        if (timeLeft > 0)
        {
            float percentage = timeLeft / maxTime;
            image.fillAmount = percentage;
            if (percentage < 0.75f && percentage > 0.35f)
            {
                image.color = medium;
            }
            else if (percentage < 0.35f) {
                image.color = low;
            } else
            {
                image.color = high;
            }
        }
    }
}
