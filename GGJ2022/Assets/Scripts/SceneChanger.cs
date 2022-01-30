using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Image panel;

    [SerializeField] Animator anim;
    string escenaACargar;

    public static SceneChanger Instance = null;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //StartCoroutine(AbrirTelon());
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += AbrirTelon;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AbrirTelon;
    }

    void AbrirTelon(Scene escena, LoadSceneMode modo)
    {
        anim.SetBool("abierto", true);
        panel.raycastTarget = false;
    }
    void CerrarTelon()
    {
        anim.SetBool("abierto", false);
        panel.raycastTarget = true;
    }
    public void CambiarEscena(string proximaEscena)
    {
        escenaACargar = proximaEscena;
        CerrarTelon();
    }
    public void VolverACargarEscena()
    {
        Debug.Log("volviendo a cargar escena");
        CambiarEscena(SceneManager.GetActiveScene().name);
    }
    void CargarEscena()
    {
        SceneManager.LoadScene(escenaACargar);
    }
    void BloquearRaycast()
    {
        panel.raycastTarget = true;
    }
}

