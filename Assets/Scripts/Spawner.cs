using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform prefab; //префаб обекта для спавна
    [SerializeField] float wait = 5; //время ожидания между спавнами в секундах

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject() 
    {
        yield return new WaitForSecondsRealtime(wait);
        Instantiate(prefab, transform.position, Quaternion.identity);
        StartCoroutine(SpawnObject());
    }
}
