using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   Camera cam;
Vector3 target = new Vector3(0.0f, 10f,0.5f);
// Use this for initialization
void Start () {
if (cam == null)
    cam = Camera.main;
}
void Update()
{
    if (Input.GetMouseButtonDown(0)) {
        Debug.Log("MouseDown");

        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        GameObject.Find("Car1").gameObject.transform.position = mousePos;
    }                                                                
}
}
