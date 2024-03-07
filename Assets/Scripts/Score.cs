using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text text;
    int score = 0;
    [SerializeField] int targetScore = 100;
    GameManager gm;
    [SerializeField] Spawner spawner;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
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
        spawner.wait -= 0.08f;
    }

    void DisplayScore()
    {
        text.text = score.ToString();
    }
}
