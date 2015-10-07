using UnityEngine;
using System.Collections;

using Constants;

public class FruitController : MonoBehaviour {
	
	public enum FruitState {
		Dropped,
		Carried,
		Grabbed,
		Released,
		Stand,
		Num
	}
	private FruitState fruitState = FruitState.Dropped;
	
	private ConveyerController conveyerController;
	
	public void Initialize() {
		this.conveyerController = ConveyerController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.fruitState == FruitState.Carried) {
			this.MoveByConveyer();
		}
	}
	
	private void MoveByConveyer() {
		this.transform.position += Vector3.left * this.conveyerController.getConveyerSpeed();
	}
	
	
	// Collisions
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag != Const.CONVEYER_TAG) {
			return;
		}
		this.ChangeState(FruitState.Carried);
	}
	
	
	// State Change
	void ChangeState(FruitState fs) {
		this.fruitState = fs;
		switch(fs){
			case FruitState.Carried:
				this.Initialize();
				break;
			case FruitState.Grabbed:
				break;
			case FruitState.Released:
				break;
			case FruitState.Stand:
				break;
			default:
				break;
		}
	}
}
