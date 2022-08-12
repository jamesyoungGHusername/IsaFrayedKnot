using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : DamagePlayer
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            ApplyEffects(collision.gameObject.GetComponent<PlayerController>());
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
