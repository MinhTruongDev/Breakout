using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    PlayerControl paddle;

    [SerializeField]
    float

            xPush = 2f,
            yPush = 10f;

    [SerializeField]
    AudioSource audioSource;

    Rigidbody2D rb;

    Vector2 ballToPaddleDistance;

    bool isStarted = false;

    private float randomFactor = 0.5f;

    private void Start()
    {
        ballToPaddleDistance = transform.position - paddle.transform.position;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isStarted)
        {
            LockBallToPaddle();
            LaunchTheBall();
        }
    }

    private void LaunchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            rb.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos =
            new Vector2(paddle.transform.position.x,
                paddle.transform.position.y);
        transform.position = paddlePos + ballToPaddleDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak =
            new Vector2(Random.Range(0.2f, randomFactor),
                Random.Range(0.2f, randomFactor));
        if (isStarted)
        {
            audioSource.Play();
            rb.velocity -= velocityTweak;
        }
    }
}
