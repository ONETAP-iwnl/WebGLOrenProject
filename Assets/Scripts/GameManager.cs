using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner; 
    [SerializeField] Scrolling back, skay; //бекграунд дорога и звезды которые будут двигатьс€ во прем€ игры
    [SerializeField] Player player;
    [SerializeField] GameObject tapText; //текст который будет просить тапнуть на экран дл€ начала игры
    [SerializeField] GameObject restartButton;
    AudioManager audioManager;
    public bool isStart = false; //начата ли игра

    private void Awake()
    {
        //оптимизаци€
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;
    }

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
    }

    public void StartGame() //метод который привод в дижение всю игру надел€€ компонеты нужными скриптами
    {
        isStart = true;
        spawner.gameObject.SetActive(true);
        back.speed = 5f; skay.speed = 0.2f; //назначение скорости элементам визуала
        player.Run();
        tapText.SetActive(false);
    }

    public IEnumerator EndGame() //куратинаё котора€ останавливает дивжение игры, выключает управление персонажем после того как преп€тсви€ будут позади
    {    
        spawner.GetComponent<Spawner>().Deactivate();
        yield return new WaitForSecondsRealtime(5);
        restartButton.SetActive(true);
        player.StopRun();
        back.speed = 0; skay.speed = 0;
    }

    public void GameOver()
    {
        spawner.GetComponent<Spawner>().Deactivate();
        Time.timeScale = 0;
        restartButton.SetActive(true);
    }

    private void Update()
    {
        if (!isStart && Input.touchCount > 0)
        {
            StartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    
}
