using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // Variable donde se almacena el valor de los puntos de daño
    public int damagePoints = 1;

    // Funcion al entrar en contacto con el collider
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto tiene el tag "Player"
        if(other.tag == "Player")
        {
            // Obtener la variable damagePoints de la funcion Damage del script Health
            other.GetComponent<Health>().Damage(damagePoints);
            StartCoroutine(Timeout());
        }
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
