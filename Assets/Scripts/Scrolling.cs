using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] public float speed = 0.2f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
