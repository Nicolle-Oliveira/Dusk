using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variável para acessar o componente de Rigidbody deste objeto
    
    private Rigidbody2D rigi;
    private CircleCollider2D colide;
    private Animator anim;
    public bool isUnderAttack = false;


    //Variável para acessar o componente de Audio
    //private AudioSource som;

    //Velocidade dos jogadores e direção do movimento
    private float speed = 10f;
    private float defaultSpeed = 10f;

    //Getters and Setters
    public float Speed{
        get{ return speed; }
        set{ speed = value; }
    }


    // Start is called before the first frame update
    public void Start(){

        rigi = GetComponent<Rigidbody2D>();
        colide = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        //som = GetComponent<AudioSource>();

    }

    /*Função chamada com um tempo definido (0.02) 
    * Comando de controle de movimento (fisica do objeto) colocado aqui para evitar errinhos 
    */
    public void FixedUpdate(){

            
            Vector3 movimento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
            transform.position = transform.position + movimento * Speed * Time.deltaTime;

            anim.SetFloat("Horizontal", movimento.x);
            anim.SetFloat("Vertical", movimento.y);
            anim.SetFloat("Speed", movimento.magnitude);

            if (Input.GetKeyDown(KeyCode.K)){
                if (isUnderAttack == true)
                {
                    
                    Invoke("Attack", 3.0f);
                    Debug.Log("Atacado");
                }
                else{
                  Debug.Log("Fora da zona");
                }    
            }
            else if(isUnderAttack == true){
                Debug.Log("Dano Recebido");
            }
            
            
            
                                           
        
        
      

        //rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, Input.GetAxisRaw("Vertical") * Speed);
    }

    // Update is called once per frame
    public void Update()
    {
        /*Obtendo entradas dos jogadores 1 e/ou 2
        * N esquecer - Edit -> Project Settings -> Input Manager
        * GetAxisRaw() usado no lugar de GetAxis() para um movimento menos fluido
        */
       // if(this.gameObject.tag == "Play1"){
      //      Direction = ;
      //  }else{
           // Direction = Input.GetAxisRaw("Controle2");
      //  }

     
        
    }

    public void Attack(){

        speed = 0;
        
    }

    public void OnTriggerEnter2D(Collider2D collision2D){
        
        //Sempre que a bola colidir com esse objeto, reproduz som

        
        //if(collision2D.gameObject.tag == "Bola"){
         //   som.Play();
       // }
       if (collision2D.gameObject.tag == "ZonadeAtaque")
       {
        //Debug.Log("Mata o Bixos");
            isUnderAttack = true;
       }

       
       
      
    }


}