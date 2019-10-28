using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float vida,partes;
    public float armadura;

   public bool intocable; 

    void Start()
    {
        //PlayerPrefs.SetFloat("KeyPartes", 0);
        partes = PlayerPrefs.GetFloat("KeyPartes");
        intocable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibirDaño(float daño) {
        if (intocable==false) { vida -= daño; }
       

       
    }
    public void AgregarPartes(float mon) {

        partes += mon;
        PlayerPrefs.SetFloat("KeyPartes", partes);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MuertePorCaida")){

            RecibirDaño(2000);

        }
    }
}
