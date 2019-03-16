using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreak;

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
        FindObjectOfType<GameStatus>().AddToScore();

        AudioSource.PlayClipAtPoint(blockBreak, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlocksDestroyed();
    }
}
