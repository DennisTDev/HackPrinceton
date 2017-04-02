using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2Main : MonoBehaviour {
	int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 3) {
			// Found 3 orbs
		}
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Orb") {
			// Collided with orb
			Destroy(other.gameObject);
			count += 1;
		}
	}
}
