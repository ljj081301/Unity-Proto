using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour {

    Rigidbody rigid;

    public int HP;
    public float movePower;
    public float jumpPower;
    public string chara_stat;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal") * movePower;
        float v = Input.GetAxisRaw("Vertical") * movePower;

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "heal_zone")
        {
            chara_stat = "heal";
            Debug.Log("힐링상태진입");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "heal_zone")
        {
            while (chara_stat == "heal")
            {
                HP = HP + 10;
                if (HP >= 200)
                    HP = 200;
                    break;
            }

            chara_stat = "none";
            Debug.Log("논상태진입");
            
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "heal_zone")
        {
            chara_stat = "damaged";
            Debug.Log("대미지상태진입");
            while (chara_stat == "damaged")
            {
                HP = HP - 30;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
