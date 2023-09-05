using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public bool attacked = false;
    public PlayerController playerController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
           
            
            
        }
    }

    

    
}
