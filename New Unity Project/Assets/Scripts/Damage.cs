using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [Header ("Bools")]
    public bool hitsPlayer;
    public bool hitsEnemy;
    public bool hitsObstacle;

    [Header ("Intagers")]
    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(Health health)
    {
        health.TakeDamage(damageAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            bool canDealDamage = false;
            Health health = other.GetComponent<Health>();
            if( (hitsPlayer && health.isPlayer)||
                (hitsEnemy && health.isEnemy)||
                (hitsObstacle && health.isObstacle))
                {
                    canDealDamage = true;
                }
            if(canDealDamage)
            {
                DealDamage(health);
            }
        }
    }

}
