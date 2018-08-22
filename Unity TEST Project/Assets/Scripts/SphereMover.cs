using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour {

    Rigidbody rigid;

    public int HP;
    public float movePower;
    public float jumpPower;
    public string chara_stat = "none";

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chara_stat == "damaged")
        {
            HP = HP - 1;
            if (HP<=0)
            {
                HP = 0;
                Destroy(gameObject);
                Debug.Log("YOU DIED");
            }
        }

    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal") * movePower;
        float v = Input.GetAxisRaw("Vertical") * movePower;

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse); 

        if (Input.GetKey(KeyCode.Space))
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
            if (chara_stat == "heal")
            {
                HP = HP + 2;
               
                if (HP >= 500)
                    HP = 500;
            }
        }

    }

  
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "heal_zone")
        {
            chara_stat = "damaged";
            Debug.Log("대미지상태진입");

        }
    }
}
