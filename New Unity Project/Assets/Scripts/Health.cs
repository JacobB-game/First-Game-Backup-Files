using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header ("Bools")]
    public bool isPlayer;
    public bool isEnemy;
    public bool isObstacle;

    [Header ("Intagers")]
    public int currentHealth;
    public int maxHealth;

    [Header ("Refs")]
    GameManager gameManager;
    HealthManager healthManager;
    

    // Start is called before the first frame update
    void Start()
    {
        
        if(isPlayer)
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            healthManager = gameManager.healthManager;
            healthManager.healthText.text = "" + maxHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0,currentHealth - damage);
        if(isPlayer)
        {
            healthManager.healthText.text = "" + currentHealth;
        }
    }

}
