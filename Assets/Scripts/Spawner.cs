using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] Obstacle[] obstancesUp; //префабы обекта для спавна сверху
    [SerializeField] Obstacle[] obstancesDown; //префабы обекта для спавна снизу
    [SerializeField] Transform spawnPointUp; //верхная точка спавна
    [SerializeField] Transform spawnPointDown; //нижняя точка спавна
    [SerializeField] public float wait = 5; //время ожидания между спавнами в секундах
    System.Random rnd = new System.Random();//встренная в unity по какойто причине не работает
    [SerializeField] Score score;
    private int indexObject; //значение которое будет выбирать рандомно для создание опредленного препятствия с определенным положением
    bool isActive = true;

    void Start()
    {       
        StartCoroutine(SpawnObject());
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    IEnumerator SpawnObject() //спавн радомного обекта каждые wait секунд
    {
        if (isActive)
        {
            yield return new WaitForSecondsRealtime(wait);//задержка
            indexObject = rnd.Next(0, 2);
            if (indexObject == 0) //выбор положения (верх или низ)
            {
                Instantiate(obstancesDown[rnd.Next(0, obstancesDown.Length)].gameObject, spawnPointDown.position, Quaternion.identity);
                score.AddScore(10); //добавление очков
            }
            else if (indexObject == 1)
            {
                Instantiate(obstancesUp[rnd.Next(0, obstancesUp.Length)].gameObject, spawnPointUp.position, Quaternion.identity);
                score.AddScore(10); //добавление очков
            }

            StartCoroutine(SpawnObject());
        }          
    }
}
