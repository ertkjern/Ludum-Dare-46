using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject gameOverMenu;

    private GameManager gameManger;
    private bool isOpen;
    private bool isGameOver;

    private void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = gameManger.IsGameOver;
        if (isGameOver)
        {
            gameOverMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOpen)
            {
                gameManger.isPaused = true;
                inGameMenu.SetActive(true);
                isOpen = true;
                Time.timeScale = 0;
            }
            else
            {
                gameManger.isPaused = false;
                inGameMenu.SetActive(false);
                isOpen = false;
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isOpen || isGameOver)
            {
                gameManger.isPaused = false;
                isOpen = false;
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }
  
    }

}
