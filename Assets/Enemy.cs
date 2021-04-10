using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //enemy behavior routine?
        //move downwards at the rate of moveSpeed-per-second
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        //health = health - 1;
        Destroy(collision.collider.gameObject);
        if(health <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        //Play Explosion effect
        //play explosion sound effect
        //add points
        Destroy(this.gameObject);
    }

    int Add (int x, int y)
    {
        return x + y;
    }
}
