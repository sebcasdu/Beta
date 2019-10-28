using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rbJugador;
    private Vector3 direccion;
    public SistemaCombate CombatSist;
    public float velocidadJugador, fuerzaSalto, fuerzaDash, porcentajeVel;
    [SerializeField] GameObject golpeEfecto;
    public int dashDesbloqueado;
    bool dobleGravedad;
    Habilidades habili;
    void Start()
    {
        dashDesbloqueado = PlayerPrefs.GetInt("KeydashDesbloqueado",0);
        fuerzaDash = PlayerPrefs.GetFloat("KeyfuerzaDash",15) ;
        habili = GetComponent<Habilidades>();
        golpeEfecto.SetActive(false);
        dobleGravedad =true;
        porcentajeVel = 1;
        rbJugador = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        


        Desplazamiento2D();
        if (Input.GetButtonDown("Jump"))
        {
            Salto();

        }
        if (rbJugador.velocity.y < 0 && dobleGravedad == true)
        {
             rbJugador.AddForce(Vector3.down * 25);
        }


    }
    public void Flipping() {

        if (rbJugador.velocity.x > 0.1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(rbJugador.velocity.x < -0.1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180,0 );
        }
    }
    bool puedeMoverse = true;
    public void Desplazamiento2D()
    {
        if (puedeMoverse) {

            Flipping();
            rbJugador.velocity = new Vector3(Input.GetAxis("Horizontal") * velocidadJugador * porcentajeVel, rbJugador.velocity.y, 0);
        }



    }
   
    bool dashUsado = false;
    public IEnumerator Dash()
    {
        habili.enabled = false;
        golpeEfecto.SetActive(true);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direccion = new Vector3(x, y, 0);
        if (direccion.magnitude > 0.1)
        {

            CombatSist.DashAtack();
            dobleGravedad = false;
            puedeMoverse = false;
            rbJugador.drag = 1.2f;           
            rbJugador.velocity = Vector3.zero;
            rbJugador.velocity += direccion.normalized * fuerzaDash;   
            dashUsado = true;

            
            

        }
        yield return new WaitForSeconds(0.5f);
        habili.enabled = true;
        golpeEfecto.SetActive(false);
        puedeMoverse = true;
        rbJugador.drag = 0;
        dobleGravedad = true;
        CombatSist.DashAtack();



    }
    public void Salto()
    {
        porcentajeVel = 0.8f;
        bool enSuelo = Physics.Raycast(gameObject.transform.position, Vector3.down, 1);
        if (enSuelo) { rbJugador.velocity = new Vector3(rbJugador.velocity.x, fuerzaSalto, 0); }
        else if (dashUsado == false)
        {
            if(dashDesbloqueado!=0)
            {
                StartCoroutine(Dash());
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            
            porcentajeVel = 1;
            dashUsado = false;
        }
    }
}
