using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreak;
    [SerializeField] GameObject blockSparklesVFX;

    // cached reference
    Level level;

    public void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();

    }

    private void DestroyBlock()
    {
        BlockBreakSound();
        Destroy(gameObject);
        TriggerSparklesVFX();

        // Counting Score
        FindObjectOfType<GameStatus>().AddToScore();
        level.BlocksDestroyed();
    }

    private void BlockBreakSound()
    {
        AudioSource.PlayClipAtPoint(blockBreak, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    }
}
