using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraOxigeno : MonoBehaviour
{
    [SerializeField] Image barra;
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
    }
}
