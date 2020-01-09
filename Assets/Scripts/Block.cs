using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkles;
   // [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // Cached References
    Level level;
    GameSession gameStatus;

    // state variables
    [SerializeField] int timesHit;  // TODO only serialized for debug purposes


    private void Start()
    {

        gameStatus = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {

        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }

    }

    private void ShowNextHitSprite()
    {

        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array" + " " + gameObject.name);
        }
        
    }

    private void DestroyBlock()
    {

        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        gameStatus.AddToScore();

    }

    private void PlayBlockDestroySFX()
    {

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1f);
        TriggerBlockSparkles();

    }

    private void TriggerBlockSparkles()
    {

        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);

    }

}
