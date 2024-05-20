using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInitializer : MonoBehaviour
{
    [SerializeField] private CombatUIUpdater uiUpdater;
    [SerializeField] private CombatManager combatManager;

    private bool pokemonSeleccionado = false;

    public void IniciarCombate()
    {
        StartCoroutine(InicializarCombate());
    }

    IEnumerator InicializarCombate()
{
    while (!pokemonSeleccionado)
    {
        yield return null;
    }

    Pkmn_Data playerPokemon = PokemonSelector.GetSelectedPokemon();
    Pkmn_Data enemyPokemon = SeleccionarPokemonAleatorio();

    combatManager.SetPlayerPokemon(playerPokemon);
    combatManager.SetEnemyPokemon(enemyPokemon);

    uiUpdater.UpdatePlayerUI(playerPokemon);
    uiUpdater.UpdateEnemyUI(enemyPokemon);

    while (!combatManager.combateAcabado)
    {
        yield return null;
    }
    PokemonSelector.ResetSelectedPokemon();
}

    Pkmn_Data SeleccionarPokemonAleatorio()
    {
        Pkmn_Data[] pokemonArray = { new Pikachu(), new Charmander(), new Chikorita(), new Cyndaquil(), new Totodile() };
        System.Random rand = new System.Random();
        int indiceAleatorio = rand.Next(0, pokemonArray.Length);
        return pokemonArray[indiceAleatorio];
    }

    public void PokemonSeleccionado()
    {
        pokemonSeleccionado = true;
    }
}