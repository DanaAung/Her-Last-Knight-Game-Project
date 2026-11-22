using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject pausedUI;
    [Space]
    [SerializeField] private Player Player;
    [SerializeField] private ObjectToProtect Princess;

    [Space]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI princessHealthText;

    [Space]
    [SerializeField] private Audio_Manager Audio_Manager;

    public int killCount;
    private bool isRunning;
    private float elapsedTime;
    private float startTime;
    private bool isPaused;
    private int lastDisplayedSecond;


    private void Awake()
    {
        instance = this;
        StopTime();
    }

    private void Update()
    {
        if (isRunning)
        {
            HandlePauseResume();

            if (!isPaused)
            {
                elapsedTime = Time.time - startTime;

                int currentSecond = Mathf.FloorToInt(elapsedTime);

                if (currentSecond != lastDisplayedSecond)
                {
                    timerText.text = currentSecond.ToString() + "s";
                    lastDisplayedSecond = currentSecond;
                }
            }
        }
        UpdateHealth();
    }

    private void HandlePauseResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pausedUI.SetActive(false);

        ResumeTime();

        isPaused = false;
        Audio_Manager.musicSource.UnPause();
    }

    private void PauseGame()
    {
        pausedUI.SetActive(true);

        StopTime();

        isPaused = true;
        Audio_Manager.musicSource.Pause();
    }

    public void EnableGameOverUI()
    {
        Time.timeScale = .5f;
        gameOverUI.SetActive(true);
        isRunning = false;
        Audio_Manager.PlayEndGame(Audio_Manager.defeat);
        Invoke(nameof(StopTime), .5f);
    }

    public void RestartLevel()
    {
        startTime = Time.time;
        elapsedTime = 0f;
        isRunning = false;

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void EnableVictoryUI()
    {
        victoryUI.SetActive(true);
        isRunning = false;
        Audio_Manager.PlayEndGame(Audio_Manager.victory);
        Invoke(nameof(StopTime), .5f);
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void AddKillCount()
    {
        killCount++;
        killCountText.text = killCount.ToString();
    }

    public void UpdateHealth()
    {
        string playerHealthString = "x" + Player.CurrentHealth.ToString();
        string princessHealthString = "x" + Princess.CurrentHealth.ToString();

        playerHealthText.text = playerHealthString;
        princessHealthText.text = princessHealthString;
    }

    public void EnableGameStartUI()
    {
        Time.timeScale = .5f;
        StartUI.SetActive(true);
    }

    public void StartLevel()
    {
        Time.timeScale = 1f;
        StartUI.SetActive(false);

        startTime = Time.time;
        elapsedTime = 0f;
        isRunning = true;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
