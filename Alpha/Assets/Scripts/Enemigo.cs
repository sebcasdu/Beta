using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemigo
{
  
    // Start is called before the first frame update
   void RecibirDaño(float daño);
    void Movimiento(float speed);
    void Ataques();
    void CheckDistance();
}
