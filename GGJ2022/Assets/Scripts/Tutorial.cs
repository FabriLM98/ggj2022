using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    int i = 0;
    [SerializeField] GameObject[] imagenes;
    [SerializeField] string[] dialogos;
    public void PasarAlProximo()
    {
        i++;
        if (i >= imagenes.Length)
        {
            i = 0;
            //QuitarPanelAyuda
            return;
        }

    }
}
