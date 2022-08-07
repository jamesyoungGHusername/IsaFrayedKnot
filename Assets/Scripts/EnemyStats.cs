using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP = 10;
    public int currentHP = 10;
    public bool alive = true;
    public AudioSource damageClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 1){
            alive = false;
            Destroy(gameObject);
        }
    }

    public void takeDamage(int i)
    {
        currentHP -= i;
        Debug.Log("Troll takes "+i+" damage and has "+currentHP+" remaining");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon")){
            takeDamage(collision.gameObject.GetComponent<BulletTravel>().damage);
            damageClip.Play();
            IEnumerator coroutine = FlashRed();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
