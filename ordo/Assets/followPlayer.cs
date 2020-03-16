using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if(player.gameObject.transform.position.x-1 < gameObject.transform.position.x)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0));
        if (player.gameObject.transform.position.x+1 > gameObject.transform.position.x)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0));

    }
}
