using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInitializer : MonoBehaviour
{
    public GameObject modeloEnemigo;
    public GameObject modeloPlayer;
    public GameObject pkmnPikachu;
    public GameObject pkmnCharmander;
    public GameObject pkmnChikorita;
    public GameObject pkmnCyndaquil;
    public GameObject pkmnTotodile;

    [SerializeField] private CombatUIUpdater uiUpdater;
    [SerializeField] private CombatManager combatManager;

    private bool pokemonSeleccionado = false;

    public void IniciarCombate()
    {
        pkmnPikachu.SetActive(false);
        pkmnCharmander.SetActive(false);
        pkmnChikorita.SetActive(false);
        pkmnCyndaquil.SetActive(false);
        pkmnTotodile.SetActive(false);
        modeloEnemigo.SetActive(true);
        modeloPlayer.SetActive(true);
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
        Pkmn_Data[] pokemonArray = { new Pikachu(), new Charmander(), new Cyndaquil(), new Totodile(), new Chikorita()};
        System.Random rand = new System.Random();
        int indiceAleatorio = rand.Next(0, pokemonArray.Length);
        switch (indiceAleatorio)
        {
            case 0:
                pkmnPikachu.SetActive(true);
                break;
            case 1:
                pkmnCharmander.SetActive(true);
                break;
            case 2:
                pkmnCyndaquil.SetActive(true);
                break;
            case 3:
                pkmnTotodile.SetActive(true);
                break;
            case 4:
                pkmnChikorita.SetActive(true);
                break;
        }
        return pokemonArray[indiceAleatorio];
    }

    public void PokemonSeleccionado()
    {
        pokemonSeleccionado = true;
    }

}