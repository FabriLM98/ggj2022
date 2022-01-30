using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoDebajo : PatoEstado
{
    float cantidadEnergiaGastadaPorSeg = 2f;
    float oxigenoRespiradoPorSegundo = 15f;
    Pato patoScript;

    public override bool EstaDebajoDelAgua()
    {
        return true;
    }
    public override void EntradoEstado(Pato pato)
    {
        patoScript = pato;
    }
    public override void PatoApretado()
    {
        Debug.Log("Pato presionado");
    }
    public override void PatoArrastrado()
    {
        Debug.Log("Pato siendo arrastrado");
        patoScript.SacarCabezaASuperficie();
    }
    public override void UpdateFrame()
    {
        patoScript.GastarEnergia(cantidadEnergiaGastadaPorSeg * Time.deltaTime);
        patoScript.ConsumirOxigeno(oxigenoRespiradoPorSegundo * Time.deltaTime);
    }
    public override void PatoSoltado()
    {
        Debug.Log("Pato soltado");
    }
    public override void AnteTrigger(Collider2D collision)
    {
        if (collision.tag == "Basura")
        {
            Debug.Log("basura colsiono");
        }
    }
}
