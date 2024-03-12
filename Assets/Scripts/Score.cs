using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text textScore; //визуальное отображение счета
    int score = 0;
    [SerializeField] int targetScore = 100; //количество очеков, которое нужно набрать чтобы завершить игру
    GameManager gm;
    [SerializeField] Spawner spawner;

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

    void DisplayScore() //отображение очков на экране
    {
        textScore.text = score.ToString();
    }
}
