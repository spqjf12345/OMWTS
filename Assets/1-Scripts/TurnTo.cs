using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//public Text way; public Text start; 





public class TurnTo : MonoBehaviour
{
   /*   void Start()
    {
        way = GetComponent<Text>();
        start = GetComponent<Text>();
    } */

    public void way(){
        SceneManager.LoadScene("Way");
    }
    public void maze(){
        SceneManager.LoadScene("Maze");
    }

   /* public void wayPointUp(){
        Debug.Log("wayEnter");
       way.color = Color.gray;
      way.fontStyle= fontStyle.italic; 
    }

     public void startPointUp(){
         Debug.Log("startEnter");
         way.fontStyle  = fontStyle.italic;
       start.color = Color.gray;
     } */ 

}
