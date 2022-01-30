using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    [SerializeField] PanelBloquearRaycast antiRaycast;
    [SerializeField] Button botonContinuar;
    [SerializeField] Button botonMenu;

    [SerializeField] Text texto;
    [SerializeField] Animator anim;
    int mostradoEnPantalla = 0;
    [SerializeField] string[] dialogos;
    void ActualizarMostrado()
    {
        mostradoEnPantalla++;
        if (mostradoEnPantalla == dialogos.Length) mostradoEnPantalla = 0;
        texto.text = dialogos[mostradoEnPantalla];
    }
    void PrenderBotones()
    {
        botonContinuar.interactable = true;
        botonMenu.interactable = true;
    }
    void ApagarBotones()
    {
        botonContinuar.interactable = false;
        botonMenu.interactable = false;
    }
    public void PonerPausa()
    {

        antiRaycast.Encender();
        Time.timeScale = 0;
        ActualizarMostrado();
        anim.SetBool("visible", true);
    }
    public void Continuar()
    {
        antiRaycast.Apagar();
        Time.timeScale = 1;
        anim.SetBool("visible", false);
    }
    public void VolverAlMenu()
    {
        //Corregir, pasar a que lo manejen los patos ante la pausa
        AkSoundEngine.PostEvent("Bubles_stop", GameObject.Find("Pato"));
        AkSoundEngine.SetState("Music", "Intro");
        SceneManager.LoadScene("MainMenu");
    }
}
