using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaLanzable :MonoBehaviour, ObjetoInteractuable
{
    bool recojido=false,recojidoOnce=false;
    Transform Jugador;
    public Transform objectsPosition;
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
        recojidoOnce = true;

    }

    public void Usar()
    {
        rb.isKinematic = false;
        gameObject.transform.parent = null;
        rb.AddExplosionForce(500, Jugador.position, 5);
        recojido = false;
         
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(recojido==false)
            {
                if (Vector3.Distance(gameObject.transform.position, Jugador.position) < 3)
                {
                Recojer();
                }
            }else
            {
                Usar();
            }

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Enemigo>()!=null)
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position,4);

            foreach (Collider col in colliders)
            {

                if (col.GetComponent<Enemigo>() != null && recojidoOnce)
                {

                    Rigidbody rigid = col.GetComponent<Rigidbody>();

                    rigid.AddExplosionForce(500, gameObject.transform.position, 5);
                    col.GetComponent<Enemigo>().RecibirDaño(40);






                }
            }

            Destroy(gameObject);
        }
    }



}
