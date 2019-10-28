using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltarin : MonoBehaviour, ObjetoInteractuable
{
    bool recojido = false;
    Transform Jugador;
    public Transform objectsPosition;
    public float fuerza;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        Jugador = FindObjectOfType<MovimientoJugador>().transform;
    }
    public void Recojer()
    {
        rb.isKinematic = true;
        gameObject.transform.position = objectsPosition.position;
        gameObject.transform.parent = Jugador;
        recojido = true;

    }

    public void Usar()
    {
        rb.isKinematic = false;
        gameObject.transform.parent = null;
        rb.AddExplosionForce(200, Jugador.position, 5);
        recojido = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (recojido == false)
            {
                if (Vector3.Distance(gameObject.transform.position, Jugador.position) < 3)
                {
                    Recojer();
                }
            }
            else
            {
                Usar();
            }

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Jugador>() != null)
        {
            collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up*fuerza);
        }
        if (collision.collider.GetComponent<Enemigo>() != null)
        {
            collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * fuerza);
        }
    }


}
