using UnityEngine;

public class Scrolling : MonoBehaviour
{
    Material material; 
    [SerializeField] Vector2 offset; //вектор от которого зависит скорость и направление перемещения фона

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime; //движение текстуры на объекте
    }
}
