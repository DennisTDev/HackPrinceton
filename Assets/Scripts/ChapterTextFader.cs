using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterTextFader : MonoBehaviour {
	public static ChapterTextFader Instance{ set; get; }
	public Text fadeText;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;
	private int i = 0; 

	public void initializeFade(string desiredText){
		fadeText.text = desiredText;

		
	}

	private void Awake(){
		Instance = this; 

	}

	public void Fade(bool showing, float duration){

		isShowing = showing;
		isInTransition = true;
		this.duration = duration; 
		transition = (isShowing) ? 0 : 1;

	}


	private void Update(){
		i++; 

		if (i == 50) {
			Fade (true, 1.25f); 
		}
		if (i == 100) {
			Fade (false, 1.25f);

		}

		if (!isInTransition) {
			return;
		}

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		fadeText.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white, transition);
	}
}
