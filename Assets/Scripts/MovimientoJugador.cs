
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 4f;
    public float velocidadGiro = 100f;

    private CharacterController controlador;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = 0;
        float z = 0;

        if (Input.GetKey(KeyCode.W)) z = 1;
        if (Input.GetKey(KeyCode.S)) z = -1;
        if (Input.GetKey(KeyCode.A)) x = -1;
        if (Input.GetKey(KeyCode.D)) x = 1;

        Vector3 movimiento = transform.right * x + transform.forward * z;

        controlador.Move(movimiento.normalized * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, -velocidadGiro * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, velocidadGiro * Time.deltaTime, 0);
    }
}
