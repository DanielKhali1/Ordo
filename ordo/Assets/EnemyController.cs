using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool left;
    public GameObject bullet;
    public float bulletSpeed;


    private void Start()
    {
        float x = Random.RandomRange(0.0f, 1.0f);
        if (x < 0.5)
            left = true;
        else
            left = false;
        
    }

    void Update()
    {

        float x = Random.RandomRange(0.0f, 1.0f);
        if(x < 0.05f)
        {

            Debug.Log("SHOT");
            GameObject b = Instantiate(bullet);
            Vector2 playerpos = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
            Vector2 mypos = gameObject.transform.position;

            Vector2 xf = playerpos - mypos;
            xf.Normalize();

            b.gameObject.transform.position = (Vector3)(mypos) + (Vector3)(xf * 2);
            b.GetComponent<Rigidbody2D>().AddForce(xf * bulletSpeed);



        }


        if (Mathf.Abs(gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").gameObject.transform.position.x ) < 10 )
            gameObject.transform.Translate(new Vector2(
                (GameObject.FindGameObjectWithTag("Player").gameObject.transform.position.x - gameObject.transform.position.x < 0)? -0.1f: 0.1f,
                0));

        else
        {
            if (left)
                gameObject.transform.Translate(new Vector2(0.1f, 0));
            else
                gameObject.transform.Translate(new Vector2(-0.1f, 0));
        }

    }
}
