using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Final : MonoBehaviour
{
    [SerializeField]
    Canvas Canvasfinal;
    // Start is called before the first frame update
    void Start()
    {
        Canvasfinal.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Jugador>()!= null)
        {
            Canvasfinal.enabled = true;

        }
    }
}
