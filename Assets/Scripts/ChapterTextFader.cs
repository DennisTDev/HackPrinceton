using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterTextFader : MonoBehaviour {
	public Text fadeText;
	public float startDelay;
	public float duration;
	public float fadeDuration;
	private float elapsed = 0;
	private float fadeElapsed = 0;
	private float transition;
	private enum State {
		WaitingToFadeIn,
		FadingIn,
		WaitingToFadeOut,
		FadingOut,
		Complete
	};
	private State state;
	private void Awake() {
		state = State.WaitingToFadeIn;
	}

	private void Update() {
		elapsed += Time.deltaTime;
		fadeElapsed += Time.deltaTime;

		if (state == State.WaitingToFadeIn && elapsed >= startDelay) {
			state = State.FadingIn;
			transition = 0;
			elapsed = 0;
			fadeElapsed = 0;
		} else if (state == State.WaitingToFadeOut && elapsed >= startDelay + startDelay) {
			state = State.FadingOut;
			transition = 1;
			elapsed = 0;
			fadeElapsed = 0;
		}

		if (state == State.FadingIn || state == State.FadingOut) {
			if (state == State.FadingIn) {
				transition = fadeElapsed / fadeDuration;
				if (transition >= fadeDuration) {
					state = State.WaitingToFadeOut;
				}
			} else if (state == State.FadingOut) {
				transition = 1 - fadeElapsed / fadeDuration;
				if (transition <= 0) {
					state = State.Complete;
				}
			}
			fadeText.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white, transition);
		}
	}
}
