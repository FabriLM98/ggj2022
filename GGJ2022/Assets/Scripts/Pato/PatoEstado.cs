using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PatoEstado
{
    public abstract void AnteTrigger(Collider2D collision);
    public abstract bool EstaDebajoDelAgua();
    public abstract void EntradoEstado(Pato pato);
    public abstract void UpdateFrame();
    public abstract void PatoApretado();
    public abstract void PatoArrastrado();
    public abstract void PatoSoltado();
}
