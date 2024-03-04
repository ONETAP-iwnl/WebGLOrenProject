using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool isGrounded = true;
    [SerializeField] private float jumpForce = 2f;
    private Rigidbody2D pRigidBody;
    private Touch theTouch;
    float timeHold = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
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

            if(transform.localScale.y > 0.5f && timeHold >= 1 && theTouch.phase == TouchPhase.Stationary)
            {
                transform.localScale = new Vector3(1, 0.5f, 1);
            }
            else if(theTouch.phase == TouchPhase.Ended) 
            {
                if(timeHold >= 1)
                {
                    transform.localScale = Vector3.one;
                }
                else if(isGrounded)
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
