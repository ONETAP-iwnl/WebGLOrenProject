using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] prefabs; //������� ������ ��� ������
    [SerializeField] Transform[] spawnPoints; //������ ���������� ������ ����� ���������� �����������
    [SerializeField] public float wait = 5; //����� �������� ����� �������� � ��������
    System.Random rnd = new System.Random();
    [SerializeField] Score score;
    private int indexObject; //�������� ������� ����� �������� �������� ��� �������� ������������ ����������� � ������������ ����������

    void Start()
    {

        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject() //����� ��������� ������ ������ wait ������
    {
        yield return new WaitForSecondsRealtime(wait);
        Debug.Log(indexObject.ToString());
        indexObject = rnd.Next(0, 2);
        Instantiate(prefabs[indexObject], spawnPoints[indexObject].position, Quaternion.identity);
        score.AddScore(10);
        StartCoroutine(SpawnObject());
    }
}
