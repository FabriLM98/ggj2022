﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pato : MonoBehaviour
{
    [SerializeField] float maximaEnergia = 100f;
    float energiaRestante;
    [SerializeField] BarraEnergia barraEnergia;

    [SerializeField] float maximoOxigeno = 100f;
    float oxigenoRestante;
    [SerializeField] BarraOxigeno barraOxigeno;


    //public delegate void TrashHit(float damage);
    //public static event TrashHit OnTrashHit;

    public delegate void Zambullir();
    public static event Zambullir SeZambullio;

    public delegate void SacarCabeza();
    public static event SacarCabeza SacoCabeza;

    public delegate void QuedarSinOxigeno();
    public static event QuedarSinOxigeno OxigenoAgotado;

    public delegate void QuedarSinEnergia();
    public static event QuedarSinEnergia EnergiaAgotada;


    PatoEstado estado = null;

    PatoDebajo patoDebajo = new PatoDebajo();
    PatoEnSuperficie patoEnSuperficie = new PatoEnSuperficie();
    // Start is called before the first frame update
    private void Awake()
    {
        CambiarEstado(patoEnSuperficie);
        energiaRestante = maximaEnergia;
        oxigenoRestante = maximoOxigeno;
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        Pez.PezComido += ComerPez;
    }
    private void OnDisable()
    {
        Pez.PezComido -= ComerPez;
    }
    public void Zambullirse()
    {
        CambiarEstado(patoDebajo);
        SeZambullio();
    }
    public void SacarCabezaASuperficie()
    {
        CambiarEstado(patoEnSuperficie);
        SacoCabeza();
    }

    void Update()
    {
        estado.UpdateFrame();
    }
    private void OnMouseDown()
    {
        estado.PatoApretado();
    }
    private void OnMouseDrag()
    {
        estado.PatoArrastrado();
    }
    private void OnMouseUp()
    {
        estado.PatoSoltado();
    }
    void CambiarEstado(PatoEstado nuevoEstado)
    {
        estado = nuevoEstado;
        estado.EntradoEstado(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        estado.AnteTrigger(collision);
    }
    public void HittedByTrash(float damage)
    {
        GastarEnergia(damage);
    }
    public void GastarEnergia(float energiaGastada)
    {
        energiaRestante -= energiaGastada;
        if (energiaRestante <= 0)
        {
            EnergiaAgotada();
        }
        else barraEnergia.ActualizarBarra(energiaRestante / maximaEnergia);
    }
    public void ConsumirOxigeno(float cantidadConsumido)
    {
        oxigenoRestante -= cantidadConsumido;
        if (oxigenoRestante <= 0) 
        {
            OxigenoAgotado();
        }
        else barraOxigeno.ActualizarBarra(oxigenoRestante / maximoOxigeno);
    }
    public void Respirar(float cantidadRespirada)
    {
        oxigenoRestante += cantidadRespirada;
        if (oxigenoRestante > maximoOxigeno) oxigenoRestante = maximoOxigeno;
        barraOxigeno.ActualizarBarra(oxigenoRestante / maximoOxigeno);
    }
    public void GanarEnergia(float energiaGanada)
    {
        energiaRestante += energiaGanada;
        if (energiaRestante > maximaEnergia) energiaRestante = maximaEnergia;
        barraEnergia.ActualizarBarra(energiaRestante / maximaEnergia);
    }
    void ComerPez(float energiaAportada)
    {
        GanarEnergia(energiaAportada);
    }
    public bool DebajoDelAgua()
    {
        return estado.EstaDebajoDelAgua();
    }
}