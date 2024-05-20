using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarCombate : MonoBehaviour
{
    public Animator transicion;
    [SerializeField]
    public AudioSource sonidoSelect;
    private readonly string nombreEscenaCombate = "CombatScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sonidoSelect.Play();
            IniciarCombate();
        }
    }

    public void IniciarCombate()
    {
        StartCoroutine(CargaDeCombate(nombreEscenaCombate));
    }

    IEnumerator CargaDeCombate(string nombreEscena)
    {
        transicion.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nombreEscena);
    }
}
