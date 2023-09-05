using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObjectsController : MonoBehaviour
{


    [SerializeField] AudioSource som;

    public void OnCollisionEnter2D(Collision2D collision2D){

        if((collision2D.gameObject.tag == "Player") && (GameManager.gameManager.Audio3D)){
            som.Play();
        }
    }
}
