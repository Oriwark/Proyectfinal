using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int playerHealth = 2;

    public int enemyDamage = 1;

    Rigidbody personajeRb;
    public static bool playerDead;
    
    // Start is called before the first frame update
    void Start()
    {
        personajeRb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            playerHealth -=enemyDamage;
            if (playerHealth > 1)
            {
                personajeRb.velocity = new Vector2(-1, 3);
            }
            else if(playerHealth <= 1)
            {
             playerDead = true;
                Destroy(gameObject, 1f);
            
             }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
