using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text textScore; //���������� ����������� �����
    int score = 0;
    GameManager gm;

    [SerializeField] int targetScore = 100; //���������� ������, ������� ����� ������� ����� ��������� ����
    [SerializeField] Spawner spawner;//������� �����������. (���� ����������� � ���������� �����������)

    private void Start()
    {
        textScore = GetComponent<TMP_Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void AddScore(int score) 
    {
        this.score += score;
        
        if(this.score > targetScore) 
        {
            StartCoroutine(gm.EndGame());
        }
        DisplayScore();
        spawner.wait -= 0.01f;
    }

    void DisplayScore() //����������� ����� �� ������
    {
        textScore.text = score.ToString();
    }
}
