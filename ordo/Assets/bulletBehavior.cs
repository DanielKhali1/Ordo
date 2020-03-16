using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public GameObject explosion;
    public GameObject EnemyDeath;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            GameObject particleBoi = Instantiate(explosion);
            particleBoi.transform.position = gameObject.transform.position;
            particleBoi.GetComponent<ParticleSystem>().Play();
            Destroy(particleBoi, 5);
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Enemy")
        {
            GameObject particleBoi = Instantiate(explosion);
            particleBoi.transform.position = gameObject.transform.position;
            particleBoi.GetComponent<ParticleSystem>().Play();
            Destroy(particleBoi, 5);

            GameObject death = Instantiate(EnemyDeath);
            death.transform.position = collision.gameObject.transform.position;
            death.GetComponent<ParticleSystem>().Play();

            Destroy(death, 5);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
