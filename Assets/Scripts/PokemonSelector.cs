using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelector : MonoBehaviour
{
    [SerializeField]
    public Button chikoritaButton;
    [SerializeField]
    public Button cyndaquilButton;
    [SerializeField]
    public Button totodileButton;

    private static Pkmn_Data selectedPokemon;

    public void Chikorita()
    {
        Pkmn_Data pokemon = new Chikorita();
        selectedPokemon = pokemon;
        Debug.Log("Pokémon seleccionado: " + selectedPokemon.nombre);
    }

    public void Cyndaquil()
    {
        Pkmn_Data pokemon = new Cyndaquil();
        selectedPokemon = pokemon;
        Debug.Log("Pokémon seleccionado: " + selectedPokemon.nombre);
    }

    public void Totodile()
    {
        Pkmn_Data pokemon = new Totodile();
        selectedPokemon = pokemon;
        Debug.Log("Pokémon seleccionado: " + selectedPokemon.nombre);
    }

    public static Pkmn_Data GetSelectedPokemon()
    {
        return selectedPokemon;
    }

    public static void ResetSelectedPokemon()
    {
        selectedPokemon = null;
    }
}
