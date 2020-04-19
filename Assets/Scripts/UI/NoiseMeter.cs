using UnityEngine;
using UnityEngine.UI;

public class NoiseMeter : MonoBehaviour
{
    private Image noiseMeter;
    private GameManager gameManager;
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        noiseMeter = GetComponent<Image>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = gameManager.DistanceToGoal;
        noiseMeter.fillAmount = distance;
        if (distance < 0.75f && distance > 0.35f)
        {
            noiseMeter.color = colors[2];
        }
        else if (distance < 0.35f)
        {
            noiseMeter.color = colors[3];
        }
        else
        {
            noiseMeter.color = colors[1];
        }
    }
}
