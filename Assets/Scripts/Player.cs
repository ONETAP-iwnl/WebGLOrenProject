using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20f; 
    [SerializeField] float waitForDown = 0.3f; // врем€ которое нужно удерживать палец на экране дл€ приседа

    bool isGrounded = true; // нахождение на земле
    private Rigidbody2D pRigidBody;
    private Touch theTouch;
    float timeHold = 0; // переменна€ дл€ хранени€ времени нахождени€ пальца на экране
    GameManager gm;

    void Start()
    {
        pRigidBody = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        PlayerJumpOrDown();
    }

    private void PlayerJumpOrDown() 
    {
        if (Input.touchCount > 0) 
        {
            theTouch = Input.GetTouch(0);
            timeHold += Time.deltaTime;

            if (transform.localScale.y > 0.5f && timeHold >= waitForDown && theTouch.phase == TouchPhase.Stationary)
            {
                transform.localScale = new Vector3(1, 0.5f, 1);
            }
            else if (theTouch.phase == TouchPhase.Ended)
            {
                if (timeHold >= waitForDown)
                {
                    transform.localScale = Vector3.one;
                }
                else if (isGrounded)
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
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gm.RestartGame();
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
