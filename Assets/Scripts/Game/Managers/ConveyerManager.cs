using UnityEngine;
using System.Collections;

using Constants;

public class ConveyerManager : SingletonMono<ConveyerManager> {
	
	private ConveyerController conveyerController;
	
	private float conveyerSpeed = Const.CONVEYER_SPEED[0];
	public float getConveyerSpeed(){return this.conveyerSpeed;}

	// Update is called once per frame
	void Update () {

	}
	
	public void Initialize() {
		this.conveyerController = ConveyerController.Instance;
		this.conveyerSpeed = Const.CONVEYER_SPEED[0];
		conveyerController.setConveyerSpeed(this.conveyerSpeed);
	}
	
	public void SpeedUp() {
		
	}
	
	public void StopConveyer() {
		this.conveyerController.StopConveyer();
	}

  public void LevelUp(int levelNum) {
    this.conveyerController.setConveyerSpeed(Const.CONVEYER_SPEED[levelNum - 1]);
  }
}
