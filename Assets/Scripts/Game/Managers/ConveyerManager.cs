using UnityEngine;
using System.Collections;

using Constants;

public class ConveyerManager : SingletonMono<ConveyerManager> {
	
	private ConveyerController conveyerController;
	
	private float conveyerSpeed = Const.CONVEYER_SPEED_1;
	public float getConveyerSpeed(){return this.conveyerSpeed;}

	// Update is called once per frame
	void Update () {

	}
	
	public void Initialize() {
		this.conveyerController = ConveyerController.Instance;
		this.conveyerSpeed = Const.CONVEYER_SPEED_1;
		conveyerController.setConveyerSpeed(this.conveyerSpeed);
	}
	
	public void SpeedUp() {
		
	}
	
	public void StopConveyer() {
		this.conveyerController.StopConveyer();
	}

  public void LevelUp(int levelNum)
  {
    switch (levelNum)
    {
      case 1: this.conveyerController.setConveyerSpeed(Const.CONVEYER_SPEED_1); return;
      case 2: this.conveyerController.setConveyerSpeed(Const.CONVEYER_SPEED_2); return;
      case 3: this.conveyerController.setConveyerSpeed(Const.CONVEYER_SPEED_3); return;
      default: return;
    }
  }

}
