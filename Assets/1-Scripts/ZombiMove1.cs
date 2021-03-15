using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiMove1 : MonoBehaviour
{
    
    Vector3 pos; //현재위치
    float delta = 1.0f; // 좌(우)로 이동가능한 (x)최대값
    float speed = 0.5f; // 이동속도
    Camera cam;

                                                                
void Start () {
    cam= Camera.main;
    pos = transform.position;
}

void Update () {
    //RaycastHit hit;
    //pos = cam.ScreenToWorldPoint(pos);
    Vector3 v = pos;
    v.y += delta * Mathf.Sin(Time.time * speed);
    //v=cam.ScreenToWorldPoint(v);
    transform.position = v;
    //Debug.Log("zombi1Pos: " + transform.position);
    //var ray = Camera.main.ScreenPointToRay(v);
    /* if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("111Find");
            if (hit.rigidbody != null){
                transform.position = hit.point;
                Debug.Log("Find");
            }
            else {
                Debug.Log("Rigidbody is null");
            }
        }*/
        //v = cam.ScreenToWorldPoint(v);
        //transform.position = v;//new Vector3(pos.x,v.y,pos.z);

    
    
    
    /* var ray = Camera.main.ScreenPointToRay(pos);

    if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null){
                GameObject.Find("zombie").gameObject.transform.position = hit.point;
                Debug.Log("Find");
            }
            else {
                Debug.Log("Rigidbody is null");
            }
        }
    //Vector3 v = pos;
    //v.y += delta * Mathf.Sin(Time.time * speed);
    //transform.position = new Vector3(pos.x,v.y,pos.z);
    //Debug.Log("zombi1Pos: " + transform.position);*/
}
}
