using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaLaguna : MonoBehaviour
{
    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        Pato.SeZambullio += DesaparecerAgua;
        Pato.SacoCabeza += AparecerAgua;
    }
    private void OnDisable()
    {
        Pato.SeZambullio -= DesaparecerAgua;
        Pato.SacoCabeza -= AparecerAgua;
    }

    void DesaparecerAgua()
    {
        Color nuevoColor = sr.color;
        nuevoColor.a = 0;
        sr.color = nuevoColor;
    }
    void AparecerAgua()
    {
        Color nuevoColor = sr.color;
        nuevoColor.a = 0.6f;
        sr.color = nuevoColor;
    }
}
