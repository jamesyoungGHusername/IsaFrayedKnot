using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.forward * speed * Time.deltaTime));
        
    }
}
