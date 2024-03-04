using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform prefab;
    [SerializeField] float wait = 5;

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
