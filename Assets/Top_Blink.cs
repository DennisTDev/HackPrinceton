using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_Blink : MonoBehaviour {

	public float speed = 5f; 
	int i = 0; 
	int startedOpen = 0; 
	int startedClose=0; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//FOR OPENING EYES
		if (Input.GetMouseButton (0) && startedOpen == 0) {
			startedOpen = 1; 
			i = 0;
		}

		if (startedOpen == 1) {
			i++; 
			if (i < 25) {
				transform.Translate (0, speed*2, 0);
			}
			if (i == 25) {
				startedOpen = 0; 
			}


		}

		//FOR CLOSING EYES
		if (Input.GetKeyDown(KeyCode.Space) && startedOpen == 0 && startedClose == 0) {
			startedClose = 1; 
			i = 0;
		}
		if (startedClose == 1) {
			i++; 
			if (i < 25) {
				transform.Translate (0, -speed*2, 0);
			}
			if (i == 25) {
				startedClose = 0; 
			}


		}

	}
}
