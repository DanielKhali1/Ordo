using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator an;
    bool left = true;

    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey("space"))
        {
            an.SetBool("inAir", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);


            an.SetBool("running", true);
            gameObject.transform.Translate(new Vector3(-0.15f, 0));
        }
        else if (Input.GetKey("d"))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);


            an.SetBool("running", true);
            gameObject.transform.Translate(new Vector3(0.15f, 0));
        }
        else
        {
            an.SetBool("running", false);
        }
        if (Input.GetKey("s"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -50));
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 0.2)
        {
            an.SetBool("inAir", false);
        }
        else
        {
            an.SetBool("inAir", true);

        }
    }

    private void flip()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1,1,1);
    }

}


