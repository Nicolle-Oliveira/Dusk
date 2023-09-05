using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variáveis para acessar os componentes
    private Rigidbody2D rigi;
    private CircleCollider2D colide;
    private Animator anim;
    [SerializeField] AudioSource passos;
    [SerializeField] AudioSource damage;

    private float speed = 10f;
    private bool hurt;
    private bool shield;

    //Getters and Setters
    public float Speed{
        get{ return speed; }
        set{ speed = value; }
    }

    public bool Hurt{
        get{ return hurt; }
        set{ hurt = value; }
    }

    public bool Shield{
        get{ return shield; }
        set{ shield = value; }
    }

    // Start is called before the first frame update
    public void Start(){

        rigi = GetComponent<Rigidbody2D>();
        colide = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    public void Update(){

        if(Input.GetKey("a")){
            Shield = true;
        }else{
            Shield = false;
        }
        
        anim.SetBool("GameOver", GameManager.gameManager.GameOver);
        anim.SetBool("Hurt", Hurt);
        anim.SetBool("Shield", Shield);

        bool estaAndando = VerificarSeEstaAndando();

        // Se o personagem estiver andando e o som não estiver tocando, inicie a reprodução
        if (estaAndando && !passos.isPlaying){
            passos.Play();
        }
        // Se o personagem não estiver andando e o som estiver tocando, pare a reprodução
        //else if (!passos && passos.isPlaying){
         //   passos.Stop();
       // }
       
    }

    /*Função chamada com um tempo definido (0.02) 
    * Comando de controle de movimento (fisica do objeto) colocado aqui para evitar errinhos 
    */
    public void FixedUpdate(){

        Vector3 movimento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        transform.position = transform.position + movimento * Speed * Time.deltaTime;

        //Enviando posição para definir animação
        anim.SetFloat("Horizontal", movimento.x);
        anim.SetFloat("Vertical", movimento.y);
        anim.SetFloat("Speed", movimento.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifique se a colisão envolve um objeto específico (opcional)
        if (collision.gameObject.CompareTag("Teste"))
        {
            Hurt = true;
            damage.Play();
            Invoke("doisMilAnosDepois", 2f);   
        }
    }

    //Funcao criada apenas para usar o invoke
    public void doisMilAnosDepois(){
        Hurt = false;
    }

    private bool VerificarSeEstaAndando()
    {
        return Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right");
    }
}