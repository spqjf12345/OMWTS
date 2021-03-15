using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using Vuforia;
public class InitObj : MonoBehaviour, ITrackableEventHandler {
private TrackableBehaviour mTrackableBehaviour; 
public GameObject zombi;
public GameObject zombi1;
public GameObject zombi2;



void Start() {
    mTrackableBehaviour = GetComponent<TrackableBehaviour>(); 
if (mTrackableBehaviour)
    mTrackableBehaviour.RegisterTrackableEventHandler(this);

}

public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
{
if (newStatus == TrackableBehaviour.Status.DETECTED ||
    newStatus == TrackableBehaviour.Status.TRACKED ||
    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
        Debug.Log("Trackable detected");

        zombi.GetComponent<ZombiMove1>().enabled=true;
        zombi1.GetComponent<ZombiMove1>().enabled=true;
        zombi2.GetComponent<ZombiMove2>().enabled=true;
        

    //other.GetComponent<Rigidbody>().useGravity= true;             //turn on the gravity of the object
    }

else {
    Debug.Log("Trackable not detected");
    //other.GetComponent<Rigidbody>().useGravity= false;    //turn off the gravity of the object
    }
}

    } 
