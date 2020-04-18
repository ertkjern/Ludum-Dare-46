using UnityEngine;

public class ViewOfSight : MonoBehaviour
{
    // First sprite should be best line of sight
    // Last sprite should be worst line of sight. // not view of sight. Worst naming ever.... No time for renaming. :P
    // Writing comments i got the time for. No doubt. 
    public Sprite[] view; // maximum 5

    private SpriteRenderer lineOfSight;
    private GameManager gameManger;

    private float timeLeft;
    private float maxTime;

    // Start is called before the first frame update
    void Start() {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lineOfSight = GetComponent<SpriteRenderer>();
        maxTime = gameManger.MaxTorchLife;
        lineOfSight.sprite = view[0];
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = gameManger.TorchLife;

        float timeLeftPercentage = timeLeft / maxTime;

        if (timeLeftPercentage < 0.80f && timeLeftPercentage > 0.60f)
        {
            lineOfSight.sprite = view[1];
        }
        else if (timeLeftPercentage < 0.60f && timeLeftPercentage > 0.40f)
        {
            lineOfSight.sprite = view[2];
        }
        else if (timeLeftPercentage < 0.40f && timeLeftPercentage > 0.20f)
        {
            lineOfSight.sprite = view[3];
        }
        else if(timeLeftPercentage < 0.20f && timeLeftPercentage > 0.10f)
        {
            lineOfSight.sprite = view[4];
        }
        else if(timeLeftPercentage < 0.10f)
        {
            lineOfSight.sprite = view[5];
        }
        else
        {
            lineOfSight.sprite = view[0];
        }
 
    }
}
