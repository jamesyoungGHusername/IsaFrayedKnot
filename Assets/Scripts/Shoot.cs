using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
            shot.GetComponent<BulletTravel>().xspeed = shot.GetComponent<BulletTravel>().xspeed * -1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
            shot.GetComponent<BulletTravel>().xspeed = 0;
            shot.GetComponent<BulletTravel>().yspeed = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
            shot.GetComponent<BulletTravel>().xspeed = 0;
            shot.GetComponent<BulletTravel>().yspeed = -0.1f;
        }

    }
   
}
