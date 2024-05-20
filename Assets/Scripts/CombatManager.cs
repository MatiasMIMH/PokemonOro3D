using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private CombatUIUpdater uiUpdater;
    [SerializeField] private Button botonAtaque1;
    [SerializeField] private Button botonAtaque2;
    [SerializeField] private Button botonAtaque3;
    [SerializeField] private Button botonAtaque4;
    [SerializeField] private HealthBar vidaController;
    [SerializeField] public TextMeshProUGUI textoDialogos;
    [SerializeField] public AudioSource sonidoDamage;
    [SerializeField] public AudioSource sonidoVictoria;
    [SerializeField] public AudioSource sonidoBatallaLoop;
    [SerializeField] public AudioSource sonidoSelect;

    private bool reproduciendoTurno = false;
    public bool combateAcabado = false;
    private Pkmn_Data playerPokemon;
    private Pkmn_Data enemyPokemon;

    public void SetPlayerPokemon(Pkmn_Data pokemon)
    {
        playerPokemon = pokemon;
        vidaController.SetMaxVidaPlayer(playerPokemon.vidaMaxima);
        vidaController.cambiarVidaPlayer(playerPokemon.vidaActual);
    }

    public void SetEnemyPokemon(Pkmn_Data pokemon)
    {
        enemyPokemon = pokemon;
        vidaController.SetMaxVidaEnemy(enemyPokemon.vidaMaxima);
        vidaController.cambiarVidaEnemy(enemyPokemon.vidaActual);
    }

    public void botonAtaque1Click()
    {
        TextMeshProUGUI textoBoton = botonAtaque1.GetComponentInChildren<TextMeshProUGUI>();
        string ataque = textoBoton.text;
        if (!reproduciendoTurno && !combateAcabado)
        {
            StartCoroutine(AtaqueSeleccionado(ataque));
        }
    }

    public void botonAtaque2Click()
    {
        TextMeshProUGUI textoBoton = botonAtaque2.GetComponentInChildren<TextMeshProUGUI>();
        string ataque = textoBoton.text;
        if (!reproduciendoTurno && !combateAcabado)
        {
            StartCoroutine(AtaqueSeleccionado(ataque));
        }
    }

    public void botonAtaque3Click()
    {
        TextMeshProUGUI textoBoton = botonAtaque3.GetComponentInChildren<TextMeshProUGUI>();
        string ataque = textoBoton.text;
        if (!reproduciendoTurno && !combateAcabado)
        {
            StartCoroutine(AtaqueSeleccionado(ataque));
        }
    }

    public void botonAtaque4Click()
    {
        TextMeshProUGUI textoBoton = botonAtaque4.GetComponentInChildren<TextMeshProUGUI>();
        string ataque = textoBoton.text;
        if (!reproduciendoTurno && !combateAcabado)
        {
            StartCoroutine(AtaqueSeleccionado(ataque));
        }
    }

    IEnumerator AtaqueSeleccionado(string attackName)
    {
        int attackIndex = playerPokemon.ataques.IndexOf(attackName);
        if (!combateAcabado)
        {
            if (!reproduciendoTurno)
                sonidoSelect.Play();
            {
                reproduciendoTurno = true;
                if (playerPokemon.velocidad >= enemyPokemon.velocidad)
                {
                    ExecutePlayerAttack(attackIndex);
                    yield return new WaitForSeconds(3);
                    if (combateAcabado) yield break;
                    sonidoDamage.Play();
                    vidaController.cambiarVidaEnemy(enemyPokemon.vidaActual);
                    if (combateAcabado) yield break;

                    yield return new WaitForSeconds(3);
                    if (enemyPokemon.vidaActual > 0)
                    {
                        ExecuteEnemyAttack();
                        yield return new WaitForSeconds(3);
                        if (combateAcabado) yield break;
                        sonidoDamage.Play();
                        vidaController.cambiarVidaPlayer(playerPokemon.vidaActual);
                        if (combateAcabado) yield break;

                        yield return new WaitForSeconds(3);
                    }
                }
                else
                {
                    ExecuteEnemyAttack();
                    yield return new WaitForSeconds(3);
                    if (combateAcabado) yield break;
                    sonidoDamage.Play();
                    vidaController.cambiarVidaPlayer(playerPokemon.vidaActual);
                    if (combateAcabado) yield break;

                    yield return new WaitForSeconds(3);
                    if (playerPokemon.vidaActual > 0)
                    {
                        ExecutePlayerAttack(attackIndex);
                        yield return new WaitForSeconds(3);
                        if (combateAcabado) yield break;
                        sonidoDamage.Play();
                        vidaController.cambiarVidaEnemy(enemyPokemon.vidaActual);
                        if (combateAcabado) yield break;

                        yield return new WaitForSeconds(3);
                    }
                }
                textoDialogos.text = $"¿Qué debería hacer {playerPokemon.nombre} ahora?";
                reproduciendoTurno = false;
            }
        }
    }

    private void ExecutePlayerAttack(int attackIndex)
    {
        int damage = CalculateDamage(playerPokemon, enemyPokemon, attackIndex);
        enemyPokemon.vidaActual -= damage;

        if (enemyPokemon.vidaActual <= 0)
        {
            enemyPokemon.vidaActual = 0;
            vidaController.cambiarVidaEnemy(enemyPokemon.vidaActual);
            sonidoBatallaLoop.Stop();
            sonidoVictoria.Play();
            textoDialogos.text = $"¡El {enemyPokemon.nombre} enemigo ha sido derrotado!";
            combateAcabado = true;
            StartCoroutine(FinalizarCombate());
        }
        else
        {
            textoDialogos.text = $"¡{playerPokemon.nombre} ha usado {playerPokemon.ataques[attackIndex]}!";
        }
    }

    private void ExecuteEnemyAttack()
    {
        int indiceRandomAtaque = Random.Range(0, enemyPokemon.ataques.Count);
        int damage = CalculateDamage(enemyPokemon, playerPokemon, indiceRandomAtaque);
        playerPokemon.vidaActual -= damage;

        if (playerPokemon.vidaActual <= 0)
        {
            playerPokemon.vidaActual = 0;
            vidaController.cambiarVidaPlayer(playerPokemon.vidaActual);
            sonidoBatallaLoop.Stop();
            textoDialogos.text = $"Tu {playerPokemon.nombre} ha sido derrotado . . .";
            combateAcabado = true;
            StartCoroutine(FinalizarCombate());
        }
        else
        {
            textoDialogos.text = $"¡El {enemyPokemon.nombre} enemigo ha usado {enemyPokemon.ataques[indiceRandomAtaque]}!";
        }
    }

    private IEnumerator FinalizarCombate()
    {
        yield return new WaitForSeconds(17);
        SceneManager.LoadScene("SampleScene");
    }

    private int CalculateDamage(Pkmn_Data attacker, Pkmn_Data defender, int indiceAtaque)
    {
        Dictionary<string, int> damageAtaque = new Dictionary<string, int>
        {
            {"Impactrueno", 15},
            {"Ataque Rápido", 10},
            {"Cola férrea", 20},
            {"Rayo", 25},
            {"Ascuas", 15},
            {"Gruñido", 0},
            {"Lanzallamas", 25},
            {"Latigazo", 15},
            {"Hoja Afilada", 20},
            {"Síntesis", 0},
            {"Pistola Agua", 15},
            {"Mordisco", 20},
            {"Hidrobomba", 30},
            {"Rueda Fuego", 25}
        };

        string nombreAtaque = attacker.ataques[indiceAtaque];
        int damageBase = damageAtaque[nombreAtaque];
        int damageTotal = damageBase + attacker.danioAtaque - defender.defensa;
        return Mathf.Max(damageTotal, 0);
    }
}
