using UnityEngine;

[RequireComponent(typeof(InputController))]
public class ControladorMovimiento : MonoBehaviour
{

    [SerializeField] float velocidad = 0f;
    [SerializeField] float vel_rotacion = 0f;

    InputController inControl = null;

    void Awake()
    {
        inControl = GetComponent<InputController>();
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        Vector2 input = inControl.Movement();
        transform.position += transform.forward * input.y * velocidad * Time.deltaTime;
        transform.Rotate(Vector3.up * input.x * vel_rotacion * Time.deltaTime);
    }
}
