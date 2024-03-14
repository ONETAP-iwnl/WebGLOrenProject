using UnityEngine;

public class TapText : MonoBehaviour
{
    void Start()
    {
        transform.LeanMoveLocalY(20f, 0.5f).setEaseOutQuart().setLoopPingPong(); //анимация подпрыгивания текста (метод из скаченного ассета)
    }
}
