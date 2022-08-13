using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float hit;
    public float knockTime;

    private void OnCollisionEnter(Collider2D collision){
        if (collision.gameObject.CompareTag("enemy")){
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null){
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * hit;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }
    private IEnumerator KnockCo(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
        }
    }
}
