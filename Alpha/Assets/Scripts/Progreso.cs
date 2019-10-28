using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progreso : MonoBehaviour
{
    public int dashDesbloqueado, CaidaLentaDesbloqueada, CaidaFuerteDesbloqueada,armaRecuperableDesbloqueada;
    public float Partes, drag, porcentajePoderCaida, velArma,fuerzaDash;
   
    public static Progreso instancia { get { return instancia; } private set { } }
    private Progreso ()
    {
         
            if (instancia != null) 
            {
             Destroy(gameObject);

            }
         
    }
    void Start()
    {
       

        dashDesbloqueado = PlayerPrefs.GetInt("KeydashDesbloqueado");
        CaidaLentaDesbloqueada = PlayerPrefs.GetInt("KeyCaidaLentaDesbloqueada");
        CaidaFuerteDesbloqueada = PlayerPrefs.GetInt("KeyCaidaFuerteDesbloqueada");
        armaRecuperableDesbloqueada = PlayerPrefs.GetInt("KeyarmaRecuperableDesbloqueada");
        Partes = PlayerPrefs.GetFloat("KeyPartes");
        drag= PlayerPrefs.GetFloat("Keydrag");
        porcentajePoderCaida= PlayerPrefs.GetFloat("KeyporcentajePoderCaida");
        velArma= PlayerPrefs.GetFloat("KeyvelArma");
        fuerzaDash = PlayerPrefs.GetFloat("KeyfuerzaDash");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
