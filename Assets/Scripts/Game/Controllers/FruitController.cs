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
  [SerializeField]
	private FruitState fruitState = FruitState.Dropped;

  [SerializeField]
  private string fruitName;
  public string getFruitName(){ return this.fruitName; }
	
	private ConveyerController conveyerController;
  private FruitsManager fruitsManager;

  private SpriteRenderer spriteRendererOffset;
	
	public void Initialize() {
		this.conveyerController = ConveyerController.Instance;
    this.fruitsManager = FruitsManager.Instance;
    this.spriteRendererOffset = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.fruitState == FruitState.Carried) {
			this.MoveByConveyer();
		} else if(this.fruitState == FruitState.Grabbed) {

    }
	}
	
	private void MoveByConveyer() {
		this.transform.position += Vector3.left * this.conveyerController.getConveyerSpeed();
	}
	
	
	// Collisions
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == Const.CONVEYER_TAG) {
			this.ChangeState(FruitState.Carried);
		} else if (other.gameObject.tag == Const.RECIEVER_TAG) {
			this.ChangeState(FruitState.Stand);
		}
	}
	
	
	// Kinect Interaction
	public void OnGrabbedKinect() {
    this.gameObject.tag = Const.GRABBED_FRUIT_TAG;
    this.gameObject.layer = Const.GRABBED_FRUIT_LAYER;
    this.GetComponent<Rigidbody2D>().isKinematic = true;
		this.ChangeState(FruitState.Grabbed);
	}
	
	public void OnReleasedKinect() {
    this.gameObject.tag = Const.RELEASED_FRUIT_TAG;
    this.GetComponent<Rigidbody2D>().isKinematic = false;
    this.ChangeState(FruitState.Released);
	}


  // Steel
	public void Steeled() {
    this.fruitsManager.SteeledFruit(this.gameObject);
    Destroy(this.gameObject);
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
