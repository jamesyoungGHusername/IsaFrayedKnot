using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP = 10;
    public int currentHP = 10;
    public bool alive = true;
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
    }
}
