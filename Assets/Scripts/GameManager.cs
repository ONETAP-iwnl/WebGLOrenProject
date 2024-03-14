using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner; 
    [SerializeField] Scrolling back, skay; //бекграунд дорога и звезды которые будут двигатьс€ во прем€ игры
    [SerializeField] GameObject player;
    [SerializeField] GameObject tapText; //текст который будет просить тапнуть на экран дл€ начала игры
    [SerializeField] GameObject restartButton;
    public bool isStart = false; //начата ли игра

    private void Awake()
    {
        //оптимизаци€
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;
    }

    public void StartGame() //метод который привод в дижение всю игру надел€€ компонеты нужными скриптами
    {
        isStart = true;
        spawner.SetActive(true);
        back.speed = 5f; skay.speed = 0.2f; //назначение скорости элементам визуала
        player.AddComponent<Player>();
        tapText.SetActive(false);
    }

    public IEnumerator EndGame() //куратинаё котора€ останавливает дивжение игры, выключает управление персонажем после того как преп€тсви€ будут позади
    {
        isStart = false;
        spawner.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        back.speed = 0; skay.speed = 0;
        restartButton.SetActive(true);
    }

    public void GameOver()
    {
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
}
