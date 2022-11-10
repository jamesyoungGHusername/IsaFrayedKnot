using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    public Camera mainCam;
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

        if (currentShotTime > 0.1f) {

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
        } else if (Input.GetMouseButtonDown(0)) {
            shooting = true;
            Vector3 clickLocation = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerLocation = transform.position;
            float horiDiff = playerLocation.x - clickLocation.x;
            float vertDiff = playerLocation.y - clickLocation.y;
            if (horiDiff < 0 && Mathf.Abs(horiDiff) > Mathf.Abs(vertDiff))
            {
                Debug.Log("clicked to the right of the player");
                
                if (currentShotTime <= 0.1f && !justShot)
                {
                    GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                    justShot = true;
                }
            }
            else if(Mathf.Abs(horiDiff) > Mathf.Abs(vertDiff))
            {
                Debug.Log("clicked to the left of the player");

                if (currentShotTime <= 0.1f)
                {
                    GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                    shot.GetComponent<BulletTravel>().xspeed = shot.GetComponent<BulletTravel>().xspeed * -1;
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                    justShot = true;
                }
            }
            if (vertDiff<0 && Mathf.Abs(horiDiff) < Mathf.Abs(vertDiff))
            {
                Debug.Log("clicked above the player");

                if (currentShotTime <= 0.1f)
                {
                    GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                    shot.GetComponent<BulletTravel>().xspeed = 0;
                    shot.GetComponent<BulletTravel>().yspeed = 0.1f;
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                    justShot = true;
                }
            }
            else if (Mathf.Abs(horiDiff) < Mathf.Abs(vertDiff))
            {
                Debug.Log("clicked below the player.");
                if (currentShotTime <= 0.1f)
                {
                    GameObject shot = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                    shot.GetComponent<BulletTravel>().xspeed = 0;
                    shot.GetComponent<BulletTravel>().yspeed = -0.1f;
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
                    justShot = true;
                }
            }
        }
        else{
            shooting = false;
        }
        if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)|| Input.GetMouseButtonDown(0)) && justShot) {
            currentShotTime = maxShotFrequency;
            justShot = false;
        }

    }
   
}
