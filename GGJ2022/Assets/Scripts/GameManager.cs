using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject panelDerrota;
    [SerializeField] Text textoDerrota;
    [SerializeField] Text textoPuntaje;
    [SerializeField] HighScore hs;
    int musicaActual = 0;
    float baseSpeed = 1;
    public static float globalSpeed;
    [SerializeField] float speedDivisor = 1f;
    float time0 = 0;
    void Start()
    {
        Time.timeScale = 1;
        globalSpeed = 1;
        time0 = Time.time;
        musicaActual = 0;

    }
    void Update()
    {
        ActualizarVelocidadGlobal();
    }
    void ActualizarVelocidadGlobal()
    {
        globalSpeed = baseSpeed + (float)System.Math.Tanh((((Time.time - time0)) / 50) - 2) + 1;
        //globalSpeed = baseSpeed + Mathf.Log10((Time.time - time0) / speedDivisor + 1);
        Debug.Log("Speed: " + globalSpeed.ToString());
        ActualizarMusica();
    }
    void ActualizarMusica()
    {
        if (musicaActual == 2) return;
        if(musicaActual == 0 && hs.HighScoreValue >= 20)
        {
            musicaActual = 1;
            AkSoundEngine.SetState("Music", "Primero");
            return;
        }
        if(musicaActual == 1 && hs.HighScoreValue >= 80)
        {
            musicaActual = 2;
            AkSoundEngine.SetState("Music", "Hardcore");
        }
    }
    private void OnEnable()
    {
        Pato.EnergiaAgotada += PerdioSinEnergia;
        Pato.OxigenoAgotado += PerdioAhogado;
    }
    private void OnDisable()
    {
        Pato.EnergiaAgotada -= PerdioSinEnergia;
        Pato.OxigenoAgotado -= PerdioAhogado;
    }
    void Perder()
    {
      
        //------
        Time.timeScale = 0;
        textoPuntaje.text = "Tu puntaje final fue: " + hs.HighScoreValue.ToString();
        panelDerrota.SetActive(true);
    }
    void PerdioAhogado()
    {
        

        Perder();
        textoDerrota.text = "Te quedaste sin oxigeno! Recuerda estar tiempo en la superficie para respirar!";
    }
    void PerdioSinEnergia()
    {
       

        Perder();
        textoDerrota.text = "Te quedaste sin energia! Recuerda comer peces de vez en cuando!";
    }
    public void ReiniciarNivel()
    {
        AkSoundEngine.SetState("Music", "Intro");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuPrincipal()
    {
        AkSoundEngine.SetState("Music", "Intro");
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
