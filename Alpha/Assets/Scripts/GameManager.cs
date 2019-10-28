using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas CanvasMuerte, canvasVictoria, canvasGeneral, canvasPausa;
    public float precio1, precio2, precio3, precio4;
    public GameObject uno, dos, tres, cuatro;
    Jugador jugador;
    Slider slidervidaJugador;
    Habilidades habJugador;
    [SerializeField] TextMeshProUGUI Llaves;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        habJugador = FindObjectOfType<Habilidades>();
        CanvasMuerte.enabled = false;
           jugador = FindObjectOfType<Jugador>();
        slidervidaJugador = canvasGeneral.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.vida <= 0) {
            Time.timeScale = 0;
            CanvasMuerte.enabled = true;

        }
        Llaves.text = jugador.partes.ToString();
        slidervidaJugador.value = jugador.vida / 100;
    }
    public void Reintentar() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Volver() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    bool paused;
    public void Pausa() {


       /* PlayerPrefs.SetInt("KeydashDesbloqueado", 0);
     PlayerPrefs.SetInt("KeyCaidaLentaDesbloqueada", 0);
        PlayerPrefs.SetInt("KeyCaidaFuerteDesbloqueada", 0);
        PlayerPrefs.SetInt("KeyarmaRecuperableDesbloqueada", 0);
        PlayerPrefs.SetFloat("KeyPartes",0);*/
        _mejoras = false;
        uno.SetActive(false); dos.SetActive(false); tres.SetActive(false); cuatro.SetActive(false);
        if (paused) {
            canvasPausa.enabled = false;
            Time.timeScale = 1;
            paused = false;
        } else { Time.timeScale =0;
            canvasPausa.enabled = true;
            paused = true;
        }
        
    }
    bool _mejoras=false;
    public void mejoras ()
    {
        if (_mejoras==false)
        {
            if (FindObjectOfType<MovimientoJugador>().dashDesbloqueado!=0)
                 { uno.SetActive(true); }
            if (habJugador.CaidaLentaUnlocked!= 0)
            { dos.SetActive(true); }
            if (habJugador.CaidaPoderosaUnlocked != 0)
            { tres.SetActive(true); }
            if (habJugador.armaRecuperableUnlocked != 0)
            { cuatro.SetActive(true); }

            _mejoras = true;
        }
        else
        {
            uno.SetActive(false); dos.SetActive(false); tres.SetActive(false); cuatro.SetActive(false);
            _mejoras = false;
        }
    }
    public void mejorarDash()
    {if(jugador.partes>=precio1)
        {
            jugador.partes -= precio1;
            PlayerPrefs.SetFloat("KeyfuerzaDash", PlayerPrefs.GetFloat("KeyfuerzaDash") + 5);
            
        FindObjectOfType<MovimientoJugador>().fuerzaDash += 5;
            Debug.Log(FindObjectOfType<MovimientoJugador>().fuerzaDash);
        }
    }
    public void mejorarDrag()
    {
        if (jugador.partes >= precio2)
        {
            jugador.partes -= precio2;
            PlayerPrefs.SetFloat("Keydrag", PlayerPrefs.GetFloat("Keydrag") + 1.5f);
        FindObjectOfType<Habilidades>().drag += 1.5f;
        }
    }
    public void mejorarPorcentajeDañoCaida()
    {
        if (jugador.partes >= precio3)
        {
            jugador.partes -= precio3;
            PlayerPrefs.SetFloat("KeyporcentajePoderCaida", PlayerPrefs.GetFloat("KeyporcentajePoderCaida") + 0.15f);
        FindObjectOfType<Habilidades>().porcentajepoderCaida += 0.2f;
        }
    }
    public void mejorarVelArma()
    {
        if (jugador.partes >= precio4)
        {
            jugador.partes -= precio4;
            PlayerPrefs.SetFloat("KeyvelArma", PlayerPrefs.GetFloat("KeyvelArma")+0.5f);
        FindObjectOfType<Habilidades>().velArma += 0.5f;

        }
    }
    
   
    


}
