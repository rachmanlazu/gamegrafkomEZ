using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour {

    public GameObject objek, instansiasi;
    float y = 2.5f, x=0f;

    // Use this for initialization
    void Start()
    {
        for (int i = 10; i >= 0; i--)
        {
            if (i % 2 == 0)
            {
                x += 5;
                instansiasi = Instantiate(objek, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (i % 3 == 0)
            {
                x -= 3;
                instansiasi = Instantiate(objek, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
