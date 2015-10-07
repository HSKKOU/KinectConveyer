using UnityEngine;
using System.Collections;

using Constants;

public class ConveyerManager : SingletonMono<ConveyerManager> {
	
	private ConveyerController conveyerController;
	
	private float conveyerSpeed = Const.DEFAULT_CONVEYER_SPEED;
	public float getConveyerSpeed(){return this.conveyerSpeed;}

	// Update is called once per frame
	void Update () {
		
	}
	
	public void Initialize() {
		this.conveyerController = ConveyerController.Instance;
		this.conveyerSpeed = Const.DEFAULT_CONVEYER_SPEED;
		conveyerController.setConveyerSpeed(this.conveyerSpeed);
	}
	
	public void SpeedUp() {
		
	}
}
