using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float sliceTime; //время нахождения в подкате

    [SerializeField] Vector2 sliceSize = new Vector2(0.5f, 0.5f);//размер коллайдера коллайдера по y во время подката
    [SerializeField] Vector2 runSize = new Vector2(0.5f, 2f); //размер колллайджера по y во время бега
    bool isSlice = false;

    bool isGrounded = true; // нахождение на земле
    private Rigidbody2D pRigidBody;
    GameManager gm;
    private Animator animator;
    CapsuleCollider2D capsulCollider2D;

    private Vector2 startPos;
    int pixelDistToDetect = 20;
    private bool fingerDown;

    void Start()
    {
        pRigidBody = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponentInChildren<Animator>();
        capsulCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (gm.isStart)
        {
            PlayerControl();
        }
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

            if (!isSlice && Input.touches[0].position.y >= startPos.y + pixelDistToDetect) //свайп вверх
            {
                fingerDown = false;

                if (isGrounded)
                {
                    Jump();
                }

                isSlice = false;
            }
            else if (!isSlice && Input.touches[0].position.y <= startPos.y - pixelDistToDetect) // свайп вниз
            {
                fingerDown = false;
                if (capsulCollider2D.size.y > sliceSize.y)
                {
                    isSlice = true;
                    StartCoroutine(Slice());
                }
                
            }


        }



    }
    IEnumerator Slice()
    {
        capsulCollider2D.size = sliceSize; //изменение размеров коллайдера
        animator.SetTrigger("Slice");
        yield return new WaitForSecondsRealtime(sliceTime); //ожидания завершения анимации
        capsulCollider2D.size = runSize;    //возвращение норм коллайдера 
        isSlice = false;
    }

    void Jump()
    {
        pRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }

    public void Run()
    {
        animator.SetBool("isRun", true);
    }

    public void StopRun()
    {
        animator.SetBool("isRun", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gm.GameOver();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}

