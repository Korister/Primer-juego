using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // variables 
    // vida del personaje
    public int health = 3;
    // Vida maxima que puede tener
    public int maxHealth = 3;
    // Estado (activo o desactivado) de la invulnerabilidad y el tiempo que dura
    public bool invencible = false;
    public float invulTime = 1f;

    void Update()
    {
        if(health <= 0)
        {
        }
    }

    // Funcion que se llama al recibir daño que hay que indicarle la variable damagePoints
    public void Damage(int damagePoints)
    {
        // Si el personaje no es invencible y su vida es mayor a 0
        if(!invencible && health > 0)
        {
            // A la vida se le restan los puntos de daño y se hace invulnerable un tiempo
            health -= damagePoints;
            StartCoroutine(Invulnerability());
        }
    }

    // Funcion que se llama al recibir curacion que hay que indicarle la variable hpRestore
    public void HealthRestore(int hpRestore)
    {
        // Si la vida es menor a vida maxima 
        if(health < maxHealth)
        {
            // A la vida se le suma la variable hpRestore
            health += hpRestore;
            // Si la vida supera a la vida maxima, la vida se iguala a la vida maxima
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }

    }

    // Funcion de invulnerabilidad
    IEnumerator Invulnerability()
    {
        // El booleano de la invulnerabilidad se transforma a true, espera la cantidad de segundos de invulTime y luego el booleano vuelve a false
        invencible = true;
        yield return new WaitForSeconds(invulTime);
        invencible = false;
    }
}
