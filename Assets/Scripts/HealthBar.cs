using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Gradient gradient;
	public Slider sliderPlayer;
	public Slider sliderEnemy;
	public Image colorBarraPlayer;
	public Image colorBarraEnemy;

	public void SetMaxVidaPlayer(int vidaMax)
	{
		sliderPlayer.maxValue = vidaMax;
		sliderPlayer.value = vidaMax;
		colorBarraPlayer.color = gradient.Evaluate(1f);
	}

	public void SetMaxVidaEnemy(int vidaMax)
	{
		sliderEnemy.maxValue = vidaMax;
		sliderEnemy.value = vidaMax;
		colorBarraEnemy.color = gradient.Evaluate(1f);
	}

	public void cambiarVidaPlayer(int vida)
	{
		sliderPlayer.value = vida;
		colorBarraPlayer.color = gradient.Evaluate(sliderPlayer.normalizedValue);
	}

	public void cambiarVidaEnemy(int vida)
	{
		sliderEnemy.value = vida;
		colorBarraEnemy.color = gradient.Evaluate(sliderEnemy.normalizedValue);
	}
}
