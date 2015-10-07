using UnityEngine;
using System.Collections;

public class ThiefManager : SingletonMono<ThiefManager> {
	
	private ThiefController thiefController;
		
	public void Initialize() {
		this.thiefController = this.GetComponent<ThiefController>();
	}
	
	public void SteelFruit() {
		this.thiefController.SteelFruit();
	}
}
