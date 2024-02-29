using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGrounded = true;
    [SerializeField] private float jumpForce = 2f;
    private Rigidbody2D pRigidBody;
    float timeHold = 0;
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

        if (Input.GetKey(KeyCode.Space) )
        {
            timeHold += Time.deltaTime;
            if (timeHold >= 1)
            {
                transform.localScale = new Vector3(1, 0.5f, 1);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(timeHold < 1)
            {
                pRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            if(timeHold >= 1)
            {
                transform.localScale = Vector3.one;
            }
            timeHold = 0;
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
