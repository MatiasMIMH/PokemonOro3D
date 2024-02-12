using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{

    public float rotationScale = 10;

    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
    }
}
