using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] Obstacle[] obstancesUp; //������� ������ ��� ������ ������
    [SerializeField] Obstacle[] obstancesDown; //������� ������ ��� ������ �����
    [SerializeField] Transform spawnPointUp; //������� ����� ������
    [SerializeField] Transform spawnPointDown; //������ ����� ������
    [SerializeField] public float wait = 5; //����� �������� ����� �������� � ��������
    System.Random rnd = new System.Random();//��������� � unity �� ������� ������� �� ��������
    [SerializeField] Score score;
    private int indexObject; //�������� ������� ����� �������� �������� ��� �������� ������������ ����������� � ������������ ����������
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

    IEnumerator SpawnObject() //����� ��������� ������ ������ wait ������
    {
        if (isActive)
        {
            yield return new WaitForSecondsRealtime(wait);//��������
            indexObject = rnd.Next(0, 2);
            if (indexObject == 0) //����� ��������� (���� ��� ���)
            {
                Instantiate(obstancesDown[rnd.Next(0, obstancesDown.Length)].gameObject, spawnPointDown.position, Quaternion.identity);
                score.AddScore(10); //���������� �����
            }
            else if (indexObject == 1)
            {
                Instantiate(obstancesUp[rnd.Next(0, obstancesUp.Length)].gameObject, spawnPointUp.position, Quaternion.identity);
                score.AddScore(10); //���������� �����
            }

            StartCoroutine(SpawnObject());
        }          
    }
}
