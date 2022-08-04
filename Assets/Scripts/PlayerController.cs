using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float xInput;
    float yInput;
    public float speed = 5.0f;
    public Facing facing;
    public bool facingLeft;
    private Animator playerAnimator;
    public GameObject weapon;
    void Start()
    {
        facing = Facing.South;
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        Debug.Log(xInput);
        if (xInput==0 && yInput == 0)
        {
            playerAnimator.SetBool("Moving", false);
        }
        else
        {
            playerAnimator.SetBool("Moving", true);
            if (Mathf.Abs(xInput) > Mathf.Abs(yInput))
            {
                playerAnimator.SetFloat("WalkSpeed", Mathf.Abs(xInput));
            }
            else
            {
                playerAnimator.SetFloat("WalkSpeed", Mathf.Abs(yInput));
            }
        }
        transform.Translate(new Vector3(xInput, yInput, 0) * Time.deltaTime * speed);
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            facing = Facing.North;
            playerAnimator.Play("WizardIdleUp");
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            facing = Facing.South;
            playerAnimator.Play("WizardIdleDown");
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            facing = Facing.West;
            facingLeft = true;
            playerAnimator.Play("WizardIdleSide");
            transform.localScale = new Vector3(-2,2,1);
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            facing = Facing.East;
            facingLeft = false;
            playerAnimator.Play("WizardIdleSide");
            transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
public enum Facing
{
    North,
    South,
    East,
    West
}
