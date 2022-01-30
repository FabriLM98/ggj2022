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
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
