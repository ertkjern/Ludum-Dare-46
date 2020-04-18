using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    private GameManager gameManger;
    private bool isOpen;

    private void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
            if (isOpen)
            {
                gameManger.isPaused = false;
                isOpen = false;
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }
  
    }

}
