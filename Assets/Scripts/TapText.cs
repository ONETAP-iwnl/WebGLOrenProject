using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapText : MonoBehaviour
{
    void Start()
    {
        transform.LeanMoveLocalY(20f, 0.5f).setEaseOutQuart().setLoopPingPong();
    }
}
