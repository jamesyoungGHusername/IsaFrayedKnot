using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse: MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }
   
    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePosition - new Vector2(transform.position.x,transform.position.y);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
