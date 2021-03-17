using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] LevelManager manager;
    [SerializeField] LevelProgression progression;
    [SerializeField] Transform paddle;
    [SerializeField] float verOffset;
    [SerializeField] float bounceCorrectionFactor;
    [SerializeField] Vector2 initialLaunchDir;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float timeBeforeCorreciton;

    private float speed;
    private float timeSinceLastBlock;
    private bool launched = false;
    private bool needsCorrection = false;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    
    public int lives = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        speed = progression.GetBallSpeed(manager.lvl);
        transform.position = new Vector2(paddle.position.x, paddle.position.y + verOffset);
    }
    
    private void Update()
    {
        timeSinceLastBlock += Time.deltaTime;
        if (launched) return;
        LaunchOnClick();
        LockBallToPaddle();
    }

    private void LaunchOnClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.velocity = initialLaunchDir.normalized * speed;
            launched = true;
        }
    }

    private void LockBallToPaddle()
    {
        var ballNewX = Mathf.Lerp(transform.position.x, paddle.position.x, 0.5f);
        transform.position = new Vector2(paddle.position.x, paddle.position.y + verOffset);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //play crash sound
        CorrectBounce();
        if (col.transform.tag == "Block")
            timeSinceLastBlock = 0;
        needsCorrection = (timeSinceLastBlock >= timeBeforeCorreciton);
    }

    private void CorrectBounce()
    {
        if (needsCorrection == false) return;
        var correctedX = Random.Range(-bounceCorrectionFactor, bounceCorrectionFactor);
        rb.velocity = (rb.velocity + new Vector2(correctedX, correctedX)).normalized * speed;
        timeSinceLastBlock = 0;
    }

    public void ResetBall()
    {
        launched = false;
        rb.velocity = Vector2.zero;
    }

}
