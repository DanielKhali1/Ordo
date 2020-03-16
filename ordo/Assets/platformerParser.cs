using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerParser : MonoBehaviour
{
    public GameObject concreteTile;
    public GameObject player;
    public GameObject Enemy;
    public string filename;

    // Start is called before the first frame update
    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(',');
            for(int j = 0; j < row.Length; j++)
            {
                if(row[j] == "b")
                {
                    GameObject b = Instantiate(concreteTile);
                    b.gameObject.transform.position = new Vector3(j * 7, i * -7, 1);
                }
                if (row[j] == "g")
                {
                    player.gameObject.transform.position = new Vector3(j * 7, i * -7, 1);
                }
                if (row[j] == "r")
                {
                    GameObject b = Instantiate(Enemy);
                    b.gameObject.transform.position = new Vector3(j * 7, i * -7, 1);
                }

            }
        }
    }

}
