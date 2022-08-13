using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionWith : MonoBehaviour
{
    public Collider2D NoTouchy;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), NoTouchy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
