using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelector : MonoBehaviour
{
    public GameObject pkmnChikorita;
    public GameObject pkmnCyndaquil;
    public GameObject pkmnTotodile;
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
        pkmnChikorita.SetActive(true);
    }

    public void Cyndaquil()
    {
        Pkmn_Data pokemon = new Cyndaquil();
        selectedPokemon = pokemon;
        Debug.Log("Pokémon seleccionado: " + selectedPokemon.nombre);
        pkmnCyndaquil.SetActive(true);
    }

    public void Totodile()
    {
        Pkmn_Data pokemon = new Totodile();
        selectedPokemon = pokemon;
        Debug.Log("Pokémon seleccionado: " + selectedPokemon.nombre);
        pkmnTotodile.SetActive(true);
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
