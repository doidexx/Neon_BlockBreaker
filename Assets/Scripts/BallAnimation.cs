using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimation : MonoBehaviour
{
    [SerializeField]
    Vector3 bounceSize;

    [SerializeField]
    AudioClip[] audioClips;

    AudioSource myAudioSource;

    [SerializeField] float randomFactor;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayCollisionSFX(col);
        LoopFix();
    }

    private void PlayCollisionSFX(Collision2D col)
    {
        transform.localScale += bounceSize;
        if (col.gameObject.GetComponent<BlockBehavior>())
        {
            myAudioSource.PlayOneShot(audioClips[1]);
        }
        myAudioSource.PlayOneShot(audioClips[0]);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        transform.localScale -= bounceSize;
    }

    void LoopFix()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
    }
}
