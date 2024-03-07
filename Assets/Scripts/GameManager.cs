using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject[] dicorations;
    [SerializeField] GameObject player;
    [SerializeField] GameObject tapText;
    [SerializeField] GameObject restartButton;
    bool isStart = false;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;
    }

    public void StartGame()
    {
        isStart = true;
        spawner.SetActive(true);
        foreach (var dicoration in dicorations)
        {
            dicoration.AddComponent<Scrolling>();
        }
        player.AddComponent<Player>();
        tapText.SetActive(false);
    }

    public IEnumerator EndGame()
    {
        isStart = true;
        spawner.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        foreach (var dicoration in dicorations)
        {
            dicoration.GetComponent<Scrolling>().speed = 0;
        }
        Destroy(player.GetComponent<Player>());
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
        SceneManager.LoadScene(0);
    }
}
