using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pkmn_Data
{
    public string nombre;
    public int vidaMaxima;
    public int vidaActual;
    public int nivel;
    public int danioAtaque;
    public int defensa;
    public int velocidad;
    public List<string> ataques;

    public Pkmn_Data(string nombre, int vidaMaxima, int nivel, int danioAtaque, int defensa, int velocidad, List<string> ataques)
    {
        this.nombre = nombre;
        this.vidaMaxima = vidaMaxima;
        this.vidaActual = vidaMaxima;
        this.nivel = nivel;
        this.danioAtaque = danioAtaque;
        this.defensa = defensa;
        this.velocidad = velocidad;
        this.ataques = ataques;
    }
}

public class Pikachu : Pkmn_Data
{
    [SerializeField]
    public Pikachu() : base("Pikachu", 100, 5, 20, 15, 25, new List<string> { "Impactrueno", "Ataque Rápido", "Cola férrea", "Rayo" }) { }
}

public class Charmander : Pkmn_Data
{
    [SerializeField]
    public Charmander() : base("Charmander", 120, 5, 25, 10, 20, new List<string> { "Ascuas", "Gruñido", "Ataque Rápido", "Lanzallamas" }) { }
}

public class Chikorita : Pkmn_Data
{
    [SerializeField]
    public Chikorita() : base("Chikorita", 90, 5, 18, 20, 15, new List<string> { "Latigazo", "Gruñido", "Hoja Afilada", "Síntesis" }) { }
}

public class Cyndaquil : Pkmn_Data
{
    [SerializeField]
    public Cyndaquil() : base("Cyndaquil", 100, 5, 25, 15, 20, new List<string> { "Ascuas", "Gruñido", "Ataque Rápido", "Rueda Fuego" }) { }
}

public class Totodile : Pkmn_Data
{
    [SerializeField]
    public Totodile() : base("Totodile", 110, 5, 22, 18, 17, new List<string> { "Pistola Agua", "Gruñido", "Mordisco", "Hidrobomba" }) { }
}
