using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject: MonoBehaviour{
    public Transform objectToFollow;
    public float moveSpeed;
    public float aggroRange;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isAggro = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = objectToFollow.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        
    }

    private void FixedUpdate() {
        Move(movement);
    }

    void Move(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
