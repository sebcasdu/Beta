using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] Collider dashCollider;
    [SerializeField] Collider golpeLateralCollider;
    [SerializeField] Collider golpeArribaCollider;
    [SerializeField] GameObject particulasGolpe;
    [SerializeField] GameObject golpeEfecto,golpeEfecto1;
    
    Jugador jugador;

    // Start is called before the first frame update
    void Start()
    {
        golpeEfecto.SetActive(false);
        golpeEfecto1.SetActive(false);
        jugador = FindObjectOfType<Jugador>();
        golpeArribaCollider.enabled = false;
        dashCollider.enabled = false;
        golpeLateralCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     

     


    
           

        if (Input.GetKey(KeyCode.W))
        {
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("s");
                StartCoroutine(GolpeArriba());


            }

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(GolpeAdelante());


        }


        if (Input.GetKeyDown(KeyCode.K))
            {

                GolpeAbajo();
                
            }
        
       

    }

    
    public void DashAtack() {

        if (dashCollider.enabled)
        {

            dashCollider.enabled = false;
        }else
        {

            
            dashCollider.enabled = true;
          
        }
      

    }
    public IEnumerator GolpeAdelante() {
        jugador.intocable = true;

        golpeEfecto.SetActive(true);
        golpeLateralCollider.enabled = true;
        

        yield return new WaitForSeconds(0.1f);

        golpeEfecto.SetActive(false);
        golpeLateralCollider.enabled = false;
        jugador.intocable = false;

    }
    public  IEnumerator GolpeArriba() {
        golpeEfecto1.SetActive(true);
        jugador.intocable = true;
        golpeArribaCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        golpeArribaCollider.enabled = false;
        jugador.intocable = false;
        golpeEfecto1.SetActive(false);
    }
    public IEnumerator GolpeAbajo() {

        yield return new WaitForSeconds(0.5f);
    }
}
