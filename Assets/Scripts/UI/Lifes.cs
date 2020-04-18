using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    public GameObject[] lifes;
    public Sprite life;
    public Sprite lostLife;

    private GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        int numberOfLifes = gameManger.Life;
        if(numberOfLifes == 3)
        {
            lifes[0].GetComponent<Image>().sprite = life;
            lifes[1].GetComponent<Image>().sprite = life;
            lifes[2].GetComponent<Image>().sprite = life;
        }
        if (numberOfLifes == 2)
        {
            lifes[0].GetComponent<Image>().sprite = life;
            lifes[1].GetComponent<Image>().sprite = life;
            lifes[2].GetComponent<Image>().sprite = lostLife;
        }
        if (numberOfLifes == 1)
        {
            lifes[0].GetComponent<Image>().sprite = life;
            lifes[1].GetComponent<Image>().sprite = lostLife;
            lifes[2].GetComponent<Image>().sprite = lostLife;
        }
        if (numberOfLifes == 0)
        {
            lifes[0].GetComponent<Image>().sprite = lostLife;
            lifes[1].GetComponent<Image>().sprite = lostLife;
            lifes[2].GetComponent<Image>().sprite = lostLife;
        }
    }
}
