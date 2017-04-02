using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterTwoMain : MonoBehaviour {

	public void onTriggerEnter(Collider info){
		if (info.name == "diamond1") {
			Debug.Log ("Diamond picked up"); 
		}
	}

}
