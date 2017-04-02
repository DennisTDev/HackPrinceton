using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour {

	[Range(1f, 50f)]
	public float speed = 10f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward, Time.deltaTime * speed);
	}
}
