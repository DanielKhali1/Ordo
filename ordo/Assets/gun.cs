using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    float x = 0;
    public Camera cam;
    public GameObject player;
    public GameObject Bullet;
    float scaleZ;


    void Start()
    {
        scaleZ = gameObject.transform.localScale.z;
    }

    void Update()
    {

        Vector2 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mypos = player.transform.position;
        Vector2 pos = mousepos - mypos;

        if (pos.x > 0)
        {
            gameObject.transform.position = new Vector3(player.gameObject.transform.position.x + 0.8f, player.gameObject.transform.position.y - 0.3f, -2);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.position = new Vector3(player.gameObject.transform.position.x - 0.8f, player.gameObject.transform.position.y - 0.3f, -2);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }   


        pos.Normalize();
        gameObject.transform.rotation = (new Quaternion(0,0,  Mathf.Atan((pos.y/pos.x)),1));

        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.rotation = (new Quaternion(0, 0, Mathf.Atan((pos.y / pos.x)), 1));
            bullet.transform.position = mypos + pos *1.5f ;
            bullet.GetComponent<Rigidbody2D>().AddForce(pos * 2000);
            Destroy(bullet, 1);

        }


    }
}
