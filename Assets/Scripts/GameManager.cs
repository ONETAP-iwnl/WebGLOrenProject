using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner; 
    [SerializeField] Scrolling back, skay; //��������� ������ � ������ ������� ����� ��������� �� ����� ����
    [SerializeField] Player player;
    [SerializeField] GameObject tapText; //����� ������� ����� ������� ������� �� ����� ��� ������ ����
    [SerializeField] GameObject restartButton;
    AudioManager audioManager;
    public bool isStart = false; //������ �� ����

    private void Awake()
    {
        //�����������
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;
    }

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
    }

    public void StartGame() //����� ������� ������ � ������� ��� ���� ������� ��������� ������� ���������
    {
        isStart = true;
        spawner.gameObject.SetActive(true);
        back.speed = 5f; skay.speed = 0.2f; //���������� �������� ��������� �������
        player.Run();
        tapText.SetActive(false);
    }

    public IEnumerator EndGame() //��������� ������� ������������� �������� ����, ��������� ���������� ���������� ����� ���� ��� ���������� ����� ������
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
