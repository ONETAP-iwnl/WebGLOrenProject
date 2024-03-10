using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    float jumpForce = 19f;
    float slicesizeY = 1f; //размер коллайдера коллайдера по y во время коллайдера
    float runsizeY = 2f; //размер колллайджера по y во время бега
    float sliceTime = 0.5f; //время нахождения в подкате
    bool isSlice = false;

    bool isGrounded = true; // нахождение на земле
    private Rigidbody2D pRigidBody;
    GameManager gm;
    private Animator animator;
    CapsuleCollider2D collider2D;

    private Vector2 startPos;
    public int pixelDistToDetect = 20;
    private bool fingerDown;



    void Start()
    {
        pRigidBody = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        PlayerControl();
    }

    private void PlayerControl()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) //получение начальног оположения пальца
        {
            // If so, we're going to set the startPos to the first touch's position, 
            startPos = Input.touches[0].position;
            // ... and set fingerDown to true to start checking the direction of the swipe.
            fingerDown = true;

        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) //получение конечного положения пальца
        {
            //startPos will be reset
            fingerDown = false;


        }

        if (fingerDown)
        {

            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect) //свайп вверх
            {
                fingerDown = false;

                if (isGrounded)
                {
                    Jump();
                }

                isSlice = false;
            }
            else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect) // свайп вниз
            {
                fingerDown = false;
                if (!isSlice && collider2D.size.y > slicesizeY)
                {
                    isSlice = true;
                    StartCoroutine(Slice());
                }
                isSlice = false;
            }


        }



    }
    IEnumerator Slice()
    {
        collider2D.size = new Vector2(1f, slicesizeY); //изменение размеров коллайдера
        animator.SetTrigger("Slice");
        yield return new WaitForSecondsRealtime(sliceTime); //ожидания завершения анимации
        collider2D.size = new Vector2(1f, runsizeY);    //возвращение норм коллайдера 
    }

    void Jump()
    {
        pRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
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

