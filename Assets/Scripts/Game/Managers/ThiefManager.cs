using UnityEngine;
using System.Collections;

using Constants;

public class ThiefManager : SingletonMono<ThiefManager> {
	
	private ThiefController thiefController;
	private TimerManager timerManager;
		
	public void Initialize() {
		this.thiefController = this.GetComponent<ThiefController>();
		this.timerManager = TimerManager.Instance;
	}
	
	public void SteelFruit(GameObject fruit) {
		this.thiefController.SteelFruit();
    fruit.GetComponent<FruitController>().Steeled();
		this.timerManager.Minus(Const.STEEL_MINUS_TIME);
	}
}
