using UnityEngine;
using UnityEngine.EventSystems;

public class DiamondCollection : MonoBehaviour {
	public EventTrigger.TriggerEvent onCollectAll;
	int count = 0;
	bool calledBack = false;
	
	void Update () {
		if (!calledBack && count == 3) {
			calledBack = true;
			BaseEventData e = new BaseEventData(EventSystem.current);
			onCollectAll.Invoke(e);
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
