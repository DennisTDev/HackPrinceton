using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Prologue : MonoBehaviour {
	public Transform player;
	public GameObject narration;
	public GameObject track;
    public Animation topEye;
    public Animation bottomEye;
	void Start () {
		Vector3 position = new Vector3(70, 600, 10);
		StartCoroutine("Go");
	}

	IEnumerator Go() {
		yield return new WaitForSeconds(3);
		narration.SetActive(true);
		yield return new WaitForSeconds(14);
        OpenEyes();
		yield return new WaitForSeconds(2);
		track.SetActive(true);
		yield return new WaitForSeconds(59);
        CloseEyes();
		yield return new WaitForSeconds(3);
        // Change scenes
        Application.Quit();
	}

    void OpenEyes()
    {
        topEye.Play("Eyelid_Top_open");
        bottomEye.Play("Eyelid_Bottom_open");

    }

    void CloseEyes()
    {
        topEye.Play("Eyelid_Top_close");
        bottomEye.Play("Eyelid_Bottom_close");
    }

	
}
