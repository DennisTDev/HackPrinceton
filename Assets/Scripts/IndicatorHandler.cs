using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorHandler : MonoBehaviour {
	public GameObject[] sensors;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < sensors.Length; i++) {
			sensors [i].SetActive (false);
		}

		StartCoroutine ("InitAnim");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BlinkingBuffer() {
		yield return new WaitForSecondsRealtime (0f);
		StartCoroutine ("Blink");
	}
	IEnumerator Blink() {
		int iterations = 0;
		while (iterations < 3) {
			yield return new WaitForSecondsRealtime (0.5f);
			for (int i = 0; i < sensors.Length; i++) {
				sensors [i].SetActive (false);
			}
			yield return new WaitForSecondsRealtime (0.5f);
			for (int i = 0; i < sensors.Length; i++) {
				sensors [i].SetActive (true);
			}
			iterations ++;
		}
	}
	IEnumerator Scroll() {
		
		for (int i = 0; i < sensors.Length; i++) {
			sensors [i].SetActive (false);
		}
		yield return new WaitForSecondsRealtime (0.5f);
		for (int i = 4; i >= 0; i--) {
			sensors [i].SetActive (true);
			yield return new WaitForSecondsRealtime (2.0f);
		}
	}

	IEnumerator InitAnim() {
		StartCoroutine ("BlinkingBuffer");
		yield return new WaitForSecondsRealtime (4.0f);
		StartCoroutine ("Scroll");
		yield return new WaitForSecondsRealtime (8.0f);
		StartCoroutine ("RandomDisconnect");
	}

	IEnumerator RandomDisconnect() {
		while (true){
			float ranTime = Random.Range (15, 65);
			yield return new WaitForSecondsRealtime (ranTime);
			StartCoroutine ("BlinkOnce");
		}
	}

	IEnumerator BlinkOnce() {
		for (int i = 0; i < sensors.Length; i++) {
			sensors [i].SetActive (false);
		}
		yield return new WaitForSecondsRealtime (1.5f);
		for (int i = 0; i < sensors.Length; i++) {
			sensors [i].SetActive (true);
		}
	}

}
