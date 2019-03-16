using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Serialized for debugging

    // cached references
    SceneLoader loadScene;

    private void Start()
    {
        loadScene = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlocksDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            loadScene.LoadNextScene();
        }
    }
}
