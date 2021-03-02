using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Sprite[] anim;
    public float jumpHeight;
    private Rigidbody2D rig;
    private int x;

    private void Awake() 
    {
        
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(Animate());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && rig.velocity.y < 0.5f)
        {
            rig.velocity += new Vector2(0 , jumpHeight);
            GetComponent<AudioSource>().Play();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(transform.position.y > 0.6f)
                rig.velocity = new Vector2(0, -jumpHeight);
        }
    }
    IEnumerator Animate()
    {
        GetComponent<SpriteRenderer>().sprite = anim[x];
        yield return new WaitForSeconds(0.175f);

        if(x == 0)
            x = 1;
        else
            x = 0;
        StartCoroutine(Animate());
    }
}