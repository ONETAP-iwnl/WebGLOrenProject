using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGrounded = true;
    [SerializeField] private float jumpForce = 2f;
    private Rigidbody2D pRigidBody;
    void Start()
    {
        pRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
            {
                pRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            pRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
