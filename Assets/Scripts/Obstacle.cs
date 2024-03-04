using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 3;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
