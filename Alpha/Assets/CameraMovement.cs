using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<Jugador>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = jugador.position+new Vector3(0,6,-20);
    }
}
