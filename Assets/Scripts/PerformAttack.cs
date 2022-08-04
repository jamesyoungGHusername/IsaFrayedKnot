using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 swingOrigin;
    public bool facingL;
    private int frameCount=0;
    public int atkPwr = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().takeDamage(atkPwr);
        }
    }
    public void setup(GameObject o)
    {
        swingOrigin = o.transform.position;
        facingL = o.GetComponent<PlayerController>().facingLeft;
        transform.RotateAround(swingOrigin, Vector3.up, 90);
        if (facingL)
        {
            transform.localScale=new Vector3(-1, 1, 1);
        }
        
        

    }
}
