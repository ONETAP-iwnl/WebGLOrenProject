using UnityEngine;

public class Scrolling : MonoBehaviour
{
    Material material; 
    [SerializeField] Vector2 offset; //������ �� �������� ������� �������� � ����������� ����������� ����

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime; //�������� �������� �� �������
    }
}
