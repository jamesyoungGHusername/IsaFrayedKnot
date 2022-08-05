using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public GameObject fireball;
    private bool allowInput = true;
    public Camera cam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    /// <summary>
    /// TO DO set roation relative to parent? I already got rotation to look at the mouse to work,
    /// however, this used a screen-to-world-point function, and is therefore not applicable to just facing a character in a particular direction.
    /// It's very easy to simply do the rotation around a single axis as though it's a platformer... hmmm. Problem for another day i think
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.GetComponent<PlayerController>().shooting = true;
            //float angle=computeAngleBetweenPoints(Vector2.left,transform.rotation)
            if (player.GetComponent<PlayerController>().facing != Facing.West)
            {
                Vector3 targetAngles = transform.eulerAngles + 180f * Vector3.up;
                transform.eulerAngles = targetAngles;
                player.GetComponent<PlayerController>().facing = Facing.West;
            }
        }else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            player.GetComponent<PlayerController>().shooting = true;
            if (player.GetComponent<PlayerController>().facing != Facing.East)
            {
                Vector3 targetAngles = transform.eulerAngles + 180f * Vector3.up;
                transform.eulerAngles = targetAngles;
                player.GetComponent<PlayerController>().facing = Facing.East;
            }
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.GetComponent<PlayerController>().shooting = true;
            if (player.GetComponent<PlayerController>().facing != Facing.North)
            {
                Vector3 targetAngles = transform.eulerAngles + 90f * Vector3.up;
                transform.eulerAngles = targetAngles;
                player.GetComponent<PlayerController>().facing = Facing.North;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.GetComponent<PlayerController>().shooting = true;
            player.GetComponent<PlayerController>().shooting = true;
            if (player.GetComponent<PlayerController>().facing != Facing.South)
            {
                Vector3 targetAngles = transform.eulerAngles + 90f * Vector3.up;
                transform.eulerAngles = targetAngles;
                player.GetComponent<PlayerController>().facing = Facing.North;
            }
        }
        else
        {
            player.GetComponent<PlayerController>().shooting = false;
        }
    }
    float computeAngleBetweenPoints(Vector2 a,Vector2 b)
    {
        var diff = b - a;
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }
    private void FixedUpdate()
    {
       
    }
}
