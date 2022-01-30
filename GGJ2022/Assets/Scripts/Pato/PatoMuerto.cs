using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoMuerto : PatoEstado
{
    public override bool EstaDebajoDelAgua()
    {
        return false;
    }
    public override void EntradoEstado(Pato pato)
    {
    }
    public override void PatoApretado()
    {
    }
    public override void PatoArrastrado()
    {
    }
    public override void UpdateFrame()
    {
    }
    public override void PatoSoltado()
    {
    }
    public override void AnteTrigger(Collider2D collision)
    {
    }
}
