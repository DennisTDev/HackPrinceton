using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class Chapter2 : MonoBehaviour {
	public Transform player;
	public RigidbodyFirstPersonController controller;
	public CloudCluster cloudCluster;
	public EyeShutter eyes;
	public GameObject narration;
	public GameObject track;
	void Start () {
		int count = 50;
		Vector3 position = new Vector3(70, 1400, 10);
		int radius = 500;
		int deltaY = 50;
		cloudCluster.Spawn(count, position, radius, deltaY);
		StartCoroutine("Go");
	}

	IEnumerator Go() {
		controller.enabled = false;
		yield return new WaitForSeconds(3);
		narration.SetActive(true);
		yield return new WaitForSeconds(18.5f);
		controller.enabled = true;
		eyes.Open();
		yield return new WaitForSeconds(2);
		track.SetActive(true);
	}

	public void End (BaseEventData e) {
		eyes.Close();
		track.SetActive(false);
		StartCoroutine("ChangeLevel");
	}

	IEnumerator ChangeLevel () {
		yield return new WaitForSeconds(3);
		Application.LoadLevel("Chapter 3");
	}

	
}
