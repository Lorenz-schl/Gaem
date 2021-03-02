using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    public Sprite[] anim;
    public Vector2 offset;
    public bool offsetY;
    public float moveSpeed = 0.13f;
    private int x;

    private void Awake() 
    {
        if(offsetY) 
        {
            moveSpeed = 0.15f;
            StartCoroutine(Animate());
        }
          
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        moveSpeed += moveSpeed / 7500;

        if(offsetY)
            moveSpeed *= 0.9f;

        if(transform.position.x <= -10)
        {
            transform.position = new Vector2(transform.position.x + 20.84f + Random.Range(offset.x, offset.y), transform.position.y);

            if (offsetY)
                transform.position = new Vector2(transform.position.x, Random.Range(1f , 3f));
        }
    }

    IEnumerator Animate()
    {
        GetComponent<SpriteRenderer>().sprite = anim[x];
        yield return new WaitForSeconds(0.1f);
        if (x == 0)
            x = 1;
        else
            x = 0;
        StartCoroutine(Animate());
    }
}