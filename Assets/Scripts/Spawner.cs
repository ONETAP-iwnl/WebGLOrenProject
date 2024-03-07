using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] prefabs; //������ ������ ��� ������
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] public float wait = 5; //����� �������� ����� �������� � ��������

    [SerializeField] Score score;
    private int indexObject;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject() 
    {
        yield return new WaitForSecondsRealtime(wait);
        indexObject = Random.Range(0, 2);
        Instantiate(prefabs[indexObject], spawnPoints[indexObject].position, Quaternion.identity);
        score.AddScore(10);
        StartCoroutine(SpawnObject());
    }
}
