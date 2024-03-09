using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] public float speed = 6f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
