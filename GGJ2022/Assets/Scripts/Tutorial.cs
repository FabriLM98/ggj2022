using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] PanelBloquearRaycast antiRaycast;
    [SerializeField] Button boton;
    [SerializeField] Text texto;
    [SerializeField] Animator anim;
    int mostradoEnPantalla = 0;
    [SerializeField] GameObject[] imagenes;
    [SerializeField] string[] dialogos;
    public void PasarAlProximo()
    {
        if (mostradoEnPantalla == imagenes.Length -1) 
        {
            CerrarTutorial();
            mostradoEnPantalla = 0;
            Debug.Log("cerrandoTutorial");
            return;
        }
        mostradoEnPantalla++;
        Debug.Log(mostradoEnPantalla);
        ActualizarMostrado();
    }
    void ActualizarMostrado()
    {
        for (int i = 0; i < imagenes.Length; i++)
        {
            if (i == mostradoEnPantalla) imagenes[i].SetActive(true);
            else imagenes[i].SetActive(false);
        }
        texto.text = dialogos[mostradoEnPantalla];
    }
    public void CerrarTutorial()
    {
        antiRaycast.Apagar();
        Time.timeScale = 1;
        anim.SetBool("visible", false);
    }
    public void AbrirTutorial()
    {
        antiRaycast.Encender();
        Time.timeScale = 0;
        ActualizarMostrado();
        anim.SetBool("visible", true);
    }
    void PrenderBoton()
    {
        boton.interactable = true;
    }
    void ApagarBoton()
    {
        boton.interactable = false;
    }
}
