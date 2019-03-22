using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration
    [SerializeField] float screenWidthInUnits = 425f;
    [SerializeField] float minX = 25f;
    [SerializeField] float maxX = 410f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
