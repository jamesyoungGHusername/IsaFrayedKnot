using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    public float maxShotFrequency = 5.0f;
    private float currentShotTime = 0.1f;
    private bool shooting = false;
    private bool justShot = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentShotTime);
        if (currentShotTime>0.1f) {
            Debug.Log("Reducing timer");
            currentShotTime -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            shooting = true;
            if (currentShotTime <= 0.1f && !justShot) {
                GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                justShot = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            shooting = true;
            if (currentShotTime <= 0.1f) {
                GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                shot.GetComponent<BulletTravel>().xspeed = shot.GetComponent<BulletTravel>().xspeed * -1;
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                justShot = true;
            }
            

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            shooting = true;
            if (currentShotTime <= 0.1f) {
                GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                shot.GetComponent<BulletTravel>().xspeed = 0;
                shot.GetComponent<BulletTravel>().yspeed = 0.1f;
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                justShot = true;
            }
            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            shooting = true;
            if (currentShotTime <= 0.1f) {
                GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                shot.GetComponent<BulletTravel>().xspeed = 0;
                shot.GetComponent<BulletTravel>().yspeed = -0.1f;
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                justShot = true;
            }
        } else {
            shooting = false;
        }
        if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && justShot) {
            currentShotTime = maxShotFrequency;
            justShot = false;
        }

    }
   
}
