using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemigoBasico : MonoBehaviour, Enemigo
{
    public Transform Target;
    Transform jugadorTransform;
    float distJugador, distTarget;
    Rigidbody rb;
    TextMeshProUGUI textoVida;
    public GameObject drop;


    public float patrolLimitX   , patrolLimitY, vida, daño, distActivacion;

    private void Start()
    {
        textoVida = GetComponentInChildren<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody>();
        jugadorTransform = FindObjectOfType<Jugador>().GetComponent<Transform>();
    }
    public void Update()
    {

        textoVida.text = vida.ToString();
        if (vida <= 0) {
            Time.timeScale = 1f;
            Drop();
            Destroy(gameObject);

        }
        CheckDistance();
        
        if (distJugador > distActivacion)
        {
           
            Movimiento(6);
        }
        if(distJugador < distActivacion)
        {
           
           
            Ataques();
                
        }

    }
    public void RecibirDaño(float d) {


        vida -= d;
        rb.AddForce((jugadorTransform.position - transform.position) * -150);
        StartCoroutine(stopfeedback());
        //rb.AddForce(new Vector3(transform.position.x-jugadorTransform.position.x *20,250,0));

    }
    public void Ataques() {
        
        transform.position = Vector3.MoveTowards(transform.position, jugadorTransform.position, 3.5f * Time.deltaTime);
        if (distJugador < 5)
        {

            rb.AddForce(Vector3.up * 10);
           

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<DamageDealer>() != null) {

            RecibirDaño(other.GetComponent<DamageDealer>().daño) ;
        }
        
    }
    public void Movimiento(float f) {
        distTarget = Vector3.Distance(transform.position, Target.position);




        if (distTarget > 2)
        {

            transform.position = Vector3.MoveTowards(transform.position, Target.position, f * Time.deltaTime);
        }
        else {
            Target.position = transform.position + Vector3.right * Random.Range(-patrolLimitX,patrolLimitX);
        }
     
        

    }
    public void OnCollisionEnter(Collision collision)
    {
        Target.position = transform.position + Vector3.right * Random.Range(-patrolLimitX, patrolLimitX);

        if (collision.collider.GetComponent<Jugador>()!= null) {

            collision.collider.GetComponent<Jugador>().RecibirDaño(daño);
        }

    }
    public void CheckDistance() {

        distJugador = Vector3.Distance(transform.position,jugadorTransform.position);

    }
    IEnumerator stopfeedback() {
        Time.timeScale = 0.01f;

        yield return new WaitForSeconds(0.001f);
            Time.timeScale = 1f;
    }
    public void Drop() {
        for(int i = 0; i < Random.Range(0, 8);i++) {

            Instantiate(drop, new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1), transform.position.z), Quaternion.identity);
        }

    }
}
