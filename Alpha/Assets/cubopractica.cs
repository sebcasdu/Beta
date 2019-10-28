using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubopractica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator stopfeedback()
    {
        Time.timeScale = 0.01f;

        yield return new WaitForSeconds(0.001f);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<DamageDealer>() != null)
        {
            StartCoroutine(stopfeedback());
           
        }

    }
}
