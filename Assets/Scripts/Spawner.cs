using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] prefabs; //префабы обекта для спавна
    [SerializeField] Transform[] spawnPoints; //пустые трансформы рикуда будут спавниться премятсявия
    [SerializeField] public float wait = 5; //время ожидания между спавнами в секундах
    System.Random rnd = new System.Random();
    [SerializeField] Score score;
    private int indexObject; //значение которое будет выбирать рандомно для создание опредленного препятствия с определенным положением

    void Start()
    {

        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject() //спавн радомного обекта каждые wait секунд
    {
        yield return new WaitForSecondsRealtime(wait);
        Debug.Log(indexObject.ToString());
        indexObject = rnd.Next(0, 2);
        Instantiate(prefabs[indexObject], spawnPoints[indexObject].position, Quaternion.identity);
        score.AddScore(10);
        StartCoroutine(SpawnObject());
    }
}
