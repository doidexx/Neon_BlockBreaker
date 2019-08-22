using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;

    [SerializeField] Level level;

    [SerializeField] GameStatus gameStatus;

    [SerializeField] ParticleSystem ps;

    [SerializeField] Sprite[] BlockStatus;

    [SerializeField] int hit; //Serialized for debugging

    [SerializeField] int maxHit;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        hit = 0;
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
            NextSprite();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HPTracker();
    }

    private void HPTracker()
    {
        if (tag == "Breakable")
        {
            TriggerSprites();
            hit++;
            if (hit == maxHit)
            {
                Destroy();
            }
            else
            {
                NextSprite();
                AudioSource.PlayClipAtPoint(audioClips[0], Camera.main.transform.position, 0.2f);

            }
        }
    }

    private void NextSprite()
    {
        GetComponent<SpriteRenderer>().sprite = BlockStatus[hit];
    }

    private void Destroy()
    {
        //TriggerSprites();
        level.SubstractBreakableBlocks();
        gameStatus.AddToScore();
        Destroy(gameObject);
        PlaySound();
    }

    private void PlaySound()
    {

        //Creates a new Audio Source to play after the object is destroyed.
        AudioSource.PlayClipAtPoint(audioClips[0], Camera.main.transform.position, 0.5f);
    }

    void TriggerSprites()
    {
        var main = ps.main;
        main.startColor = GetComponent<SpriteRenderer>().color;
        GameObject VFX = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
        Destroy(VFX, 0.5f);
    }
}
