using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour

{
    public int CaidaLentaUnlocked,CaidaPoderosaUnlocked,armaRecuperableUnlocked;
    bool armaPlantada=false;
    Rigidbody rb;
    int poderCaida;
    float timer = 0;

    public float drag,porcentajepoderCaida, velArma;
    [SerializeField] GameObject armaRecuperable;
    bool enSuelo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        CaidaLentaUnlocked = PlayerPrefs.GetInt("KeyCaidaLentaDesbloqueada");
        CaidaPoderosaUnlocked = PlayerPrefs.GetInt("KeyCaidaFuerteDesbloqueada");
        armaRecuperableUnlocked = PlayerPrefs.GetInt("KeyarmaRecuperableDesbloqueada");

        drag = PlayerPrefs.GetFloat("Keydrag",6);
        porcentajepoderCaida = PlayerPrefs.GetFloat("KeyporcentajePoderCaida",0.5f);
        velArma = PlayerPrefs.GetFloat("KeyvelArma",1);
    }

    // Update is called once per frame
    void Update()
    {
        if (CaidaLentaUnlocked!=0)
        {
            CaidaLenta(drag);
        }
        if(CaidaPoderosaUnlocked!=0)
        {  

            if(Input.GetKeyDown(KeyCode.S))
            {
                enSuelo = Physics.Raycast(gameObject.transform.position, Vector3.down, 1);
                if(enSuelo==false)
                {
                    poderCaida += 1;
                    
                }

            }

        }
        if(armaRecuperableUnlocked!=0)
        {
            if (Input.GetKey(KeyCode.J))
            {
              
               timer += Time.deltaTime;
                if(timer>0.2f)
                {

                   
                
                   if(armaPlantada==false)
                   {
                      
                        armaRecuperable.SetActive(true);
                       armaRecuperable.transform.position = gameObject.transform.position;
                         armaPlantada = true;
                   }
                 
               

                }
            }
            if(Input.GetKeyUp(KeyCode.J))
            {

                timer = 0;
              StartCoroutine(RecuperarArma());
             
            }
        }


    }
    public void CaidaLenta(float _drag)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            enSuelo = Physics.Raycast(gameObject.transform.position, Vector3.down, 1);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (enSuelo == false)
            {
                rb.drag = _drag;
            }
        }
        else
        {
            rb.drag = 0;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {

           
            Collider[] colliders=  Physics.OverlapSphere(gameObject.transform.position, poderCaida);

            foreach (Collider col  in colliders)
            {

                if (col.GetComponent<Enemigo>()!=null)
                {

                    Rigidbody rigid = col.GetComponent<Rigidbody>();
                    
                        rigid.AddExplosionForce(poderCaida * 50 * porcentajepoderCaida, gameObject.transform.position, poderCaida*3 * porcentajepoderCaida);
                        col.GetComponent<Enemigo>().RecibirDaño(poderCaida*4*porcentajepoderCaida);
                    





                }
            }

            poderCaida = 0;
        }
    }
    IEnumerator RecuperarArma()
    {

        for(int i =0; i<120;i++)
        {
            armaRecuperable.transform.position = Vector3.MoveTowards(armaRecuperable.transform.position, gameObject.transform.position, 15*velArma * Time.deltaTime);
            yield return null;
        }
        if(Vector3.Distance(armaRecuperable.transform.position,gameObject.transform.position)<5)
        {
            armaRecuperable.SetActive(false);
            armaPlantada = false;
            yield break;
            
        }

    }


}
