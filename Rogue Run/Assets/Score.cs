using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public float score = 0;

    void Awake()
    {
        
    }
    void FixedUpdate()
    {
        GetComponent<TextMesh>().text = "Score: " + Mathf.RoundToInt(score);

        score += 0.25f;
    }
}