using UnityEngine;
using System.Collections;

using Constants;

public class SteelAreaController : MonoBehaviour {
	
	private ThiefManager thiefManager;
	
	void Start() {
		this.thiefManager = ThiefManager.Instance;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == Const.FRUIT_TAG) {
			this.thiefManager.SteelFruit(other.gameObject);
		}
	}
}
