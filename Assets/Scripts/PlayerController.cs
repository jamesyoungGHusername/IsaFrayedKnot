using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float xInput;
    float yInput;
    public float speed = 5.0f;
    public Rigidbody2D rb;
    Vector2 movement;
    [HideInInspector] public bool shooting = false;
    public Facing facing;
    public bool facingLeft;
    private Animator playerAnimator;
    public GameObject fireball;
    public int health = 10;
    
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
        
        movement.x = xInput;
        movement.y = yInput;
        
        if (xInput==0 || yInput == 0)
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

        //This method of changing which sprite is displayed is quick and dirty, could likely be better.
        //When overhauled, the character should face the direction they're shooting while they're shooting.
        
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
            transform.localScale = new Vector3(-2, 2, 1);

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
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void decrementHealth(int by) {
        if(health > 0) {
            health -= by;
            if(by > 0){
                 IEnumerator coroutine = FlashRed();
                StartCoroutine(coroutine);
            }
        }
    }
        private IEnumerator FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
public enum Facing
{
    North,
    South,
    East,
    West
}
