using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject gameOverMenu;
    public GameObject victoryMenu;
    public GameObject instructionMenu;

    private GameManager gameManger;
    private bool isOpen;
    private bool isGameOver;
    private bool isVictory;
    private bool hasShownInstructionVideo;

    private void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        ShowInstructions();
    }

    void ShowInstructions()
    {
        Time.timeScale = 0;
        instructionMenu.SetActive(true);
        gameManger.isPaused = true;
        TurnDownSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasShownInstructionVideo)
        {
            if(Input.GetKeyDown(KeyCode.Return)){
                TurnSoundOn();
                instructionMenu.SetActive(false);
                Time.timeScale = 1;
                hasShownInstructionVideo = true;
                gameManger.isPaused = false;
            }
        }
        else
        {
            isGameOver = gameManger.IsGameOver;
            isVictory = gameManger.IsVictory;
            if (isVictory)
            {
                TurnDownSound();
                victoryMenu.SetActive(true);
                gameManger.isPaused = true;
                Time.timeScale = 0;
            }
            if (isGameOver || isVictory)
            {
                TurnDownSound();
                gameOverMenu.SetActive(true);
                gameManger.isPaused = true;
                Time.timeScale = 0;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isOpen)
                {
                    TurnDownSound();
                    gameManger.isPaused = true;
                    inGameMenu.SetActive(true);
                    isOpen = true;
                    Time.timeScale = 0;
                }
                else
                {
                    TurnSoundOn();
                    gameManger.isPaused = false;
                    inGameMenu.SetActive(false);
                    isOpen = false;
                    Time.timeScale = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isOpen || isGameOver || isVictory)
                {
                    gameManger.isPaused = false;
                    isOpen = false;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

    void TurnDownSound()
    {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    void TurnSoundOn()
    {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();
        }
    }


}
