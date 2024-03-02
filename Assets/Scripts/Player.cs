using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGrounded = true;
    [SerializeField] private float jumpForce = 2f;
    private Rigidbody2D pRigidBody;
    private Touch theTouch;
    float timeHold = 0;
    void Start()
    {
        pRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            timeHold += Time.deltaTime;

            if(theTouch.phase == TouchPhase.Stationary && timeHold >= 1)
            {
                transform.localScale = new Vector3(1, 0.5f, 1);
            }
            
            if(theTouch.phase == TouchPhase.Ended) 
            {
                if(timeHold >= 1)
                {
                    transform.localScale = Vector3.one;
                }
                else if(timeHold < 1 && isGrounded)
                {
                    pRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }
                timeHold = 0;
            }
            
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
