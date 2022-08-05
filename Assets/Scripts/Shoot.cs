using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    public float shotForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireShot();
        }
    }
    void FireShot()
    {
        GameObject shot = Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * shotForce, ForceMode2D.Impulse);
    }
}
