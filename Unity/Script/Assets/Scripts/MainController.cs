using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    public int timer = 0;//public int 타입의 timer라는 변수를 만듬
    public GameObject capsule;//캡슐이라는 이름의 게임 오브젝트 변수를 생성
    public float speed = 3.0f;

	// Use this for initialization
	void Start () {
        Debug.Log("초기화가 이루어졌습니다.");//로그를 출력하는 함수
        capsule = GameObject.Find("Capsule");//캡슐 변수를 실제 캡슐이라는 이름의 오브젝트에 연결
    }
	
	// Update is called once per frame
	void Update () {
        timer = timer + 1;
        Debug.Log(timer + "번째 업데이트");
        capsule.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);
        //Time.deltaTime : 어떤 컴퓨터로 실행하든 프로그램이 같은 속도로 작동하게 시간의 싱크로율을 맞춰줌
        /*this.transform.Translate(Vector3.forward * speed * Time.deltaTime);으로
         
         * public GameObject capsule;
         * capsule = GameObject.Find("Capsule");
         * capsule.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);
         
         의 세줄을 대체 가능*/
    }
}
