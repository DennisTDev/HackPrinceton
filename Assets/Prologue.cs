using UnityEngine;
using System.Collections;
public class Prologue : MonoBehaviour {
	public Transform player;
	public CloudCluster cloudCluster;
	public EyeShutter eyes;
	public GameObject narration;
	public GameObject track;
	void Start () {
		int count = 50;
		Vector3 position = new Vector3(70, 600, 10);
		int radius = 500;
		int deltaY = 50;
		cloudCluster.Spawn(count, position, radius, deltaY);
		StartCoroutine("Go");
	}

	IEnumerator Go() {
		yield return new WaitForSeconds(3);
		narration.SetActive(true);
		yield return new WaitForSeconds(14);
		eyes.Open();
		yield return new WaitForSeconds(2);
		track.SetActive(true);
		yield return new WaitForSeconds(59);
		eyes.Close();
		yield return new WaitForSeconds(3);
		Application.LoadLevel("Chapter 1");
	}

	
}
