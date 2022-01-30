using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoEnSuperficie : PatoEstado
{
    float cantidadEnergiaGastadaPorSeg = 8f;
    float oxigenoRecuperadoPorSegundo = 5f;
    Pato patoScript;
    float speed = 8;
    float bordeHorizontal = 2.3f;
    float bordeVertical = 4.2f;
    public override void EntradoEstado(Pato pato)
    {
        patoScript = pato;
    }
    public override bool EstaDebajoDelAgua()
    {
        return false;
    }
    public override void PatoApretado()
    {
        Debug.Log("Pato presionado");
    }
    public override void PatoArrastrado()
    {
        Debug.Log("Pato siendo arrastrado");
        Vector3 mousePosition = Input.mousePosition;
        Vector3 nuevaPosicionPato = Camera.main.ScreenToWorldPoint(mousePosition);
        nuevaPosicionPato.z = 0;

        patoScript.transform.Translate((nuevaPosicionPato - patoScript.transform.position) * speed * Time.deltaTime);
    }
    public override void UpdateFrame()
    {
        patoScript.GastarEnergia(cantidadEnergiaGastadaPorSeg * Time.deltaTime);
        patoScript.Respirar(oxigenoRecuperadoPorSegundo * Time.deltaTime);
        VerBordesHorizontales();
        VerBordesVerticales();
    }
    public override void PatoSoltado()
    {
        Debug.Log("Pato soltado");
        patoScript.Zambullirse();
    }
    void VerBordesHorizontales()
    {
        if (patoScript.transform.position.x > bordeHorizontal) patoScript.transform.position = new Vector2(bordeHorizontal, patoScript.transform.position.y);
        if (patoScript.transform.position.x < bordeHorizontal * -1) patoScript.transform.position = new Vector2(-bordeHorizontal, patoScript.transform.position.y);
    }
    void VerBordesVerticales()
    {
        if (patoScript.transform.position.y > bordeVertical) patoScript.transform.position = new Vector2(patoScript.transform.position.x,bordeVertical);
        if (patoScript.transform.position.y < -bordeVertical) patoScript.transform.position = new Vector2(patoScript.transform.position.x, -bordeVertical);
    }
    public override void AnteTrigger(Collider2D collision)
    {
        if(collision.tag == "Basura")
        {
            Basura basuraScript = collision.gameObject.GetComponent<Basura>();
            patoScript.HittedByTrash(basuraScript.DamagePerHit);
            basuraScript.ColisionConPato();

        }
    }
}
