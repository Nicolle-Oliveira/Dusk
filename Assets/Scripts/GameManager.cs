using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Varável para acessar esse script pelos outros
    public static GameManager gameManager;

    //Variáveis de acessibilidade
    [SerializeField] bool audio3D;
    [SerializeField] bool legendas;
    [SerializeField] bool somAmbiente;

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    private AudioSource som;

    //Variveis para o timer
    [SerializeField] Text timerTxt;
    [SerializeField] int tempo_total;
    [SerializeField] int tempo_restante;

    private bool gameOver = false;

    public bool GameOver{
        get{ return gameOver; }
        set{ gameOver = value; }
    }

    public bool Audio3D{
        get{ return audio3D; }
        set{ audio3D = value; }
    }

    public bool Legendas{
        get{ return legendas; }
        set{ legendas = value; }
    }

    public bool SomAmbiente{
        get{ return somAmbiente; }
        set{ somAmbiente = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null){
            gameManager = this;
        }
        som = GetComponent<AudioSource>();


        //Mouse invisível durante a partida
        Cursor.visible = false;
        Begin(tempo_total);
        
    }

    // Update is called once per frame
    void Update(){

        //Ao apertar esc
        if(Input.GetKeyDown(KeyCode.Escape)){
            
            //Se a tela de pause estiver ligada
            if(pausePanel.activeSelf){
                ResumeGame();

            //Se não
            } else{
                pausePanel.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
                
            }
        }

        if(SomAmbiente == true){
            som.Play();
        }
    }

    //Recomeçar fase
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    //Voltar ao jogo
    public void ResumeGame(){

        pausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    //Ir para a tela de menu
    public void GoToMenu(){
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void GoToFases(){
        //Ir para a tela do jogo
        SceneManager.LoadScene("Fases", LoadSceneMode.Single);
        //Tempo correndo normalmente
        Time.timeScale = 1;
    }

    public void Begin(int Second){
        tempo_restante = Second;
        StartCoroutine(UpdateTimer());
    }

    public IEnumerator UpdateTimer(){

        while(tempo_restante >= 0){
            timerTxt.text = $"{tempo_restante / 60:00} : {tempo_restante % 60:00}";
            tempo_restante--;
            yield return new WaitForSeconds(1f);
        }
        onEnd();
    }

    public void onEnd(){

        GameOver = true;
        Invoke("gameOverFunction", 1.0f);
        print("End");
    }

    public void gameOverFunction(){

        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

}
