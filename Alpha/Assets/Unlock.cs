using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    MovimientoJugador mov;
    Habilidades hab;
    void Start()
    {
        mov = FindObjectOfType<MovimientoJugador>();
        hab = FindObjectOfType<Habilidades>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)

    {

        Debug.Log("what");
        if(other.CompareTag("GolpeJugador"))
        {
           if(gameObject.name== "UnlockDash")
            {
                mov.dashDesbloqueado = 1;
                PlayerPrefs.SetInt("KeydashDesbloqueado",1);
                Destroy(gameObject);
            }
            if (gameObject.name == "UnlockCaidaLenta")
            {
                hab.CaidaLentaUnlocked = 1;
                PlayerPrefs.SetInt("KeyCaidaLentaDesbloqueada",1);
                Destroy(gameObject);
            }
            if (gameObject.name == "UnlockCaidaPoderosa")
            {

                hab.CaidaPoderosaUnlocked = 1;
                PlayerPrefs.SetInt("KeyCaidaFuerteDesbloqueada",1);
                Destroy(gameObject);
            }
            if (gameObject.name == "UnlockArmaRecuperable")
            {
                hab.armaRecuperableUnlocked = 1;
                PlayerPrefs.SetInt("KeyarmaRecuperableDesbloqueada",1);
                Destroy(gameObject);

            }

        }
    }

}
