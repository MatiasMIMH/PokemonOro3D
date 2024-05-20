using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEnemy
{
    public string nombre;
    public int vidaMaxima;
    public int nivel;
    public int danioAtaque;
    public int defensa;
    public int velocidad;
    public List<string> ataques;

    public DatosEnemy(string nombre, int vidaMaxima, int nivel, int danioAtaque, int defensa, int velocidad, List<string> ataques)
    {
        this.nombre = nombre;
        this.vidaMaxima = vidaMaxima;
        this.nivel = nivel;
        this.danioAtaque = danioAtaque;
        this.defensa = defensa;
        this.velocidad = velocidad;
        this.ataques = ataques;
    }
}