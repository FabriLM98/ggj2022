using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduccion : MonoBehaviour
{
    [SerializeField] CanvasGroup cg;
    [SerializeField] GameObject[] textos;
    [SerializeField] float speed;
    [SerializeField] SceneChanger sc;
    [SerializeField] Button botonSiguiente;
    int textoActual = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PasarSiguienteTexto()
    {
        if(textoActual == textos.Length-1)
        {
            sc.CambiarEscena("MainMenu");
            return;
        }
        StartCoroutine(PasarSiguienteTextoAnim());
        
    }
    IEnumerator PasarSiguienteTextoAnim()
    {
        botonSiguiente.interactable = false;
        while (cg.alpha > 0)
        {
            cg.alpha -= Time.deltaTime * speed;
            yield return null;
        }
        textoActual++;
        textos[textoActual - 1].SetActive(false);
        textos[textoActual].SetActive(true);
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime * speed;
            yield return null;
        }
        botonSiguiente.interactable = true;
    }
}
