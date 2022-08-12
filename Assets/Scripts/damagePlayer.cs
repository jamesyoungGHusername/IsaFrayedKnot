using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {

            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

            ApplyEffects(pc);
     
        }

    }
    protected void ApplyEffects(PlayerController pc) {
        pc.decrementHealth(damage);
    }
}
