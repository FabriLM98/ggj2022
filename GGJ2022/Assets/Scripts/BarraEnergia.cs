using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnergia : MonoBehaviour
{
    [SerializeField]Image barra;
    [SerializeField] Exclamacion exclamacion;


    public delegate void ImportanteBarraEnergia(float porcentaje);
    public static event ImportanteBarraEnergia AdvertenciaBarraEnergia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActualizarBarra(float porcentajeEnergiaRestante)
    {
        barra.fillAmount = porcentajeEnergiaRestante;
        MostrarAdvertencia();
    }
    void MostrarAdvertencia()
    {
        if(!exclamacion.EstaVisible() && barra.fillAmount <= 0.4f)
        {
            AdvertenciaBarraEnergia(barra.fillAmount);
            exclamacion.Mostrar();
            return;
        }
        if(exclamacion.EstaVisible() && barra.fillAmount >= 0.4f)
        {
            exclamacion.Ocultar();
            return;
        }
    }
}
