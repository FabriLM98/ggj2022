using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraOxigeno : MonoBehaviour
{
    [SerializeField] Image barra;
    [SerializeField] Exclamacion exclamacion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActualizarBarra(float porcentajeOxigenoRestante)
    {
        barra.fillAmount = porcentajeOxigenoRestante;
        MostrarAdvertencia();
    }
    void MostrarAdvertencia()
    {
        if (!exclamacion.EstaVisible() && barra.fillAmount <= 0.35f)
        {
            exclamacion.Mostrar();
            return;
        }
        if (exclamacion.EstaVisible() && barra.fillAmount >= 0.4f)
        {
            exclamacion.Ocultar();
            return;
        }
    }
}
