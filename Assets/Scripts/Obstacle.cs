using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float lifeTime = 10; //через сколько секунд будет уничтожен объект

    private void Start()
    {
        StartCoroutine(DestroyOldObject());
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    IEnumerator DestroyOldObject()
    {
        yield return new WaitForSecondsRealtime(lifeTime);
        Destroy(gameObject);
    }
}
