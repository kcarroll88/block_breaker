using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // CONFIG PARAMETERS
    [SerializeField] AudioClip blockBreak;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int blockHealth;
    [SerializeField] Sprite[] damageSprite;

    // CACHED REFERENCES
    Level level;

    // STATE
    [SerializeField] int timesHit; // serialized for debug purposes

    public void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= blockHealth)
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
        if (damageSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageSprite[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        if (tag == "Breakable")
        {
            BlockBreakSound();
            Destroy(gameObject);
            TriggerSparklesVFX();

            // COUNTING SCORE
            FindObjectOfType<GameStatus>().AddToScore();
            level.BlocksDestroyed();
        }
        else if (tag == "Unbreakable")
        {
            BlockBreakSound();
        }
    }

    private void BlockBreakSound()
    {
        AudioSource.PlayClipAtPoint(blockBreak, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
