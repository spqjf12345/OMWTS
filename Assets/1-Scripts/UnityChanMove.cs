using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMove : MonoBehaviour {

    Rigidbody rbody;
    Animator ani;
    float speed = 0f; //현재 캐릭터 속도
    float runningspeed = 3f; //달리기로 모션 전환할 기준 속도
    float maxspeed = 5f; //최대 속도 제한
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");//-1이 왼쪽 방향키. 1이 오른쪽 방향키
        float v = Input.GetAxisRaw("Vertical");//-1이 아래 방향키. 1이 위 방향키
        bool Moving = h != 0 || v != 0; //어느 키든 입력하면 true로 취급.
        if(Moving)//bool Moving 변수가 true
        {
            Turn(h, v); //방향을 튼다 
            Move(); //전방으로 이동한다.
        }
        else //키를 입력하지않은경우 
        {
            if(speed>0f)speed -= 60f * Time.fixedDeltaTime; //현재 속도를 감속시킨다.
            if (speed < 0f) speed = 0f; //속도가 음수인경우 0으로 고정.
        }
        if (speed > 0f && speed < runningspeed) ani.SetFloat("Speed", 1f);//움직이는 상태에서 뛰는 속도만큼 도달하지는않은경우 걷는 모션을
        else if (speed > runningspeed) ani.SetFloat("Speed", 3f);//움직이는 상태에서 뛰는 속도 이상인경우 뛰는 모션을
        else ani.SetFloat("Speed", 0f);//움직이지 않는경우 대기모션을 부여한다.
        ani.SetFloat("Direction", h);//현재 방향에 대한 값 부여
    }

    void Turn(float left,float up)
    {
        Quaternion newdir = Quaternion.LookRotation(new Vector3(left, 0, up));
        rbody.rotation = Quaternion.Slerp(rbody.rotation, newdir, 0.1f); //바라보는 방향으로 "부드럽게"몸을 회전한다.
    }

    void Move()//방향은 transform.forward, 즉 캐릭터의 전방으로 고정되있으므로 매개변수는 없다.
    {
        Vector3 movement = transform.forward.normalized* speed * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + movement);
        if(speed<maxspeed)speed += 1.5f*Time.fixedDeltaTime; //최대속도 미만일시 가속한다.
    }

}
