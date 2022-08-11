using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float xspeed = 0.01f;
    public float yspeed = 0.0f;
    public int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void FixedUpdate()
    {
        Vector2 position = transform.position   ;
        position.x += xspeed;
        position.y += yspeed;
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
        
    }
}
