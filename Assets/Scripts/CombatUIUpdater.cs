using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombatUIUpdater : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI playerNameText;
    [SerializeField] public TextMeshProUGUI playerLevelText;
    [SerializeField] public Slider playerHealthBar;
    [SerializeField] public TextMeshProUGUI enemyNameText;
    [SerializeField] public TextMeshProUGUI enemyLevelText;
    [SerializeField] public Slider enemyHealthBar;
    [SerializeField] public TextMeshProUGUI botonAtaque1;
    [SerializeField] public TextMeshProUGUI botonAtaque2;
    [SerializeField] public TextMeshProUGUI botonAtaque3;
    [SerializeField] public TextMeshProUGUI botonAtaque4;

    public void UpdatePlayerUI(Pkmn_Data playerPokemon)
    {
        playerNameText.text = playerPokemon.nombre;
        playerLevelText.text = "LVL " + playerPokemon.nivel;
        playerHealthBar.maxValue = playerPokemon.vidaMaxima;
        playerHealthBar.value = playerPokemon.vidaMaxima;
        botonAtaque1.text = playerPokemon.ataques[0];
        botonAtaque2.text = playerPokemon.ataques[1];
        botonAtaque3.text = playerPokemon.ataques[2];
        botonAtaque4.text = playerPokemon.ataques[3];

    }

    public void UpdateEnemyUI(Pkmn_Data enemyPokemon)
    {
        enemyNameText.text = enemyPokemon.nombre;
        enemyLevelText.text = "LVL " + enemyPokemon.nivel;
        enemyHealthBar.maxValue = enemyPokemon.vidaMaxima;
        enemyHealthBar.value = enemyPokemon.vidaMaxima;
    }
}
