using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator transicion;
    private bool pokemonSeleccionado = false;
    public AudioSource sonidoSelect;
    public AudioSource sonidoBattleBegins;
    public AudioSource sonidoBattleLoop;
    [SerializeField]
    public CombatInitializer initializer;

    void Start()
    {
        StartCoroutine(CheckPokemonSelection());
    }

    IEnumerator CheckPokemonSelection()
    {
        while (!pokemonSeleccionado)
        {
            Pkmn_Data playerPokemon = PokemonSelector.GetSelectedPokemon();
            if (playerPokemon != null)
            {
                pokemonSeleccionado = true;
                initializer.PokemonSeleccionado();
                initializer.IniciarCombate();
                sonidoSelect.Play();
                yield return new WaitForSeconds(0.5f);
                sonidoBattleBegins.Play();
                IniciarCombate();
                yield return new WaitForSeconds(2.6f);
                sonidoBattleLoop.Play();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void IniciarCombate()
    {
        StartCoroutine(CargaDeCombate());
    }

    IEnumerator CargaDeCombate()
    {
        transicion.SetTrigger("Start");
        yield return new WaitForSeconds(1);
    }
}
