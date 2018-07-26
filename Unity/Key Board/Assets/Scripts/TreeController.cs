using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);//(x, y, z)방향으로 움직이게 설정
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);//(x, y, z)방향으로 움직이게 설정
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);//(x, y, z)방향으로 움직이게 설정
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -speed * Time.deltaTime);//(x, y, z)방향으로 움직이게 설정
        }


    }
}
