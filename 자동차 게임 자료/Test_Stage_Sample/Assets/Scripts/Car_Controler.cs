using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controler : MonoBehaviour
{
    private float speedZ = 75F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            this.transform.Translate(Vector3.left * speedZ * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(Vector3.forward * speedZ * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(Vector3.back * speedZ * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            this.transform.Translate(Vector3.right * speedZ * Time.deltaTime);
        }
    }
}
