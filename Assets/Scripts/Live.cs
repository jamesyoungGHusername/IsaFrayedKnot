using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP = 10;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void decrementHealth(int by) {
        if (currentHP > 0) {
            currentHP -= by;
            IEnumerator coroutine = FlashRed();
            StartCoroutine(coroutine);
        }
    }
    public void incrementHealth(int by) {

    }
    private IEnumerator FlashRed() {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
