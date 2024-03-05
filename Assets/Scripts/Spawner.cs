using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform prefab; //������ ������ ��� ������
    [SerializeField] float wait = 5; //����� �������� ����� �������� � ��������
    [SerializeField] float firstWait = 5;

    void Start()
    {
        StartCoroutine(SpawnObject(firstWait));
    }

    IEnumerator SpawnObject(float wait) 
    {
        yield return new WaitForSecondsRealtime(wait);
        Instantiate(prefab, transform.position, Quaternion.identity);
        StartCoroutine(SpawnObject(this.wait));
    }
}
