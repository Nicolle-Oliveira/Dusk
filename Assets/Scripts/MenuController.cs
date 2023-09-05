using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void GoToFases(){
        //Ir para a tela do jogo
        SceneManager.LoadScene("Fases", LoadSceneMode.Single);
        //Tempo correndo normalmente
        Time.timeScale = 1;
    }

    public void GoToMenu(){
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void GoLevelUm(){
        //Ir para a tela do jogo
        SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
        //Tempo correndo normalmente
        Time.timeScale = 1;
    }

    public void GoLevelDois(){
        //Ir para a tela do jogo
        SceneManager.LoadScene("Lvl2", LoadSceneMode.Single);
        //Tempo correndo normalmente
        Time.timeScale = 1;
    }
    
    public void Quit(){
        //Sair do jogo
        Application.Quit();
        Debug.Log(" Quit game!");
    }

    
}
