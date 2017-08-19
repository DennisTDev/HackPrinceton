using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EyeShutter : MonoBehaviour {
	public enum EyeShutterState {
		Idle,
		Opening,
		Closing
	};
	public bool isInitiallyClosed;
	public EyeShutterState state;
	public float duration;
	public RectTransform topLid;
	public RectTransform bottomLid;
	private Vector2 screenSize;
	private float elapsed = 0; 
	void Start () {
		RectTransform rect = GetComponent<RectTransform>();
		screenSize = rect.sizeDelta;
		if (isInitiallyClosed) {
			SetTopLidY(screenSize.y / 2);
			SetBottomLidY(0);
		} else {
			SetTopLidY(screenSize.y);
			SetBottomLidY(-screenSize.y / 2);
		}
		topLid.sizeDelta = new Vector2(topLid.sizeDelta.x, screenSize.y / 2);
		bottomLid.sizeDelta = new Vector2(bottomLid.sizeDelta.x, screenSize.y / 2);
	}

	public void Open () {
		state = EyeShutterState.Opening;
		elapsed = 0;
	}

	public void Close () {
		state = EyeShutterState.Closing;
		elapsed = 0;
	}
	
	private void SetTopLidY (float posY) {
		Vector3 p = topLid.localPosition;
		topLid.localPosition = new Vector3(p.x, posY - (screenSize.y / 2), p.z);
	}

	private void SetBottomLidY (float posY) {
		Vector3 p = bottomLid.localPosition;
		bottomLid.localPosition = new Vector3(p.x, posY - (screenSize.y / 2), p.z);
	}

	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed > duration) {
			elapsed = duration;
		}
		float t = elapsed / duration;
		switch (state) {
			case EyeShutterState.Opening:
				SetTopLidY((screenSize.y / 2) + (15 * t));
				SetBottomLidY(-(15 * t));
				break;
			case EyeShutterState.Closing:
				SetTopLidY((screenSize.y) - (15 * t));
				SetBottomLidY(-(15 * (1 - t)));
				break;
		}
		if (elapsed == duration) {
			elapsed = 0;
			state = EyeShutterState.Idle;
		}
	}
}
