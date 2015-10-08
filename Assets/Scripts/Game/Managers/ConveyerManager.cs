using UnityEngine;
using System.Collections;

using Constants;

public class ConveyerManager : SingletonMono<ConveyerManager> {
	
	private ConveyerController conveyerController;

	// Update is called once per frame
	void Update () {

	}
	
	public void Initialize() {
		this.conveyerController = ConveyerController.Instance;
		conveyerController.setConveyerSpeed(Const.CONVEYER_SPEED[0]);
	}
	
	public void StopConveyer() {
		this.conveyerController.StopConveyer();
	}

  public void LevelUp(int levelNum) {
    this.conveyerController.setConveyerSpeed(Const.CONVEYER_SPEED[levelNum - 1]);
  }
}
