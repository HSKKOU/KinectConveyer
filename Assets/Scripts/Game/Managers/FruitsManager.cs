using UnityEngine;
using System.Collections;

using Constants;

public class FruitsManager : SingletonMono<FruitsManager> {

  private GameManager gameManager;
  private KinectGrabReleaseManager kinectGrabReleaseManager;
	
	public GameObject[] fruitSamples;
	private GameObject nextFruit;
	
	public enum FruitManagerState {
		Init,
		Playing,
		Result
	}
	private FruitManagerState fruitManagerState = FruitManagerState.Init;
	
	private float currentTime;
	private float fruitDropTime = Const.FRUIT_DROP_SPAN_1;

	[SerializeField]
	private Vector3 emitterPosition;
	
	public void Initialize() {
    this.gameManager = GameManager.Instance;
    this.kinectGrabReleaseManager = KinectGrabReleaseManager.Instance;
		this.currentTime = 0.0f;
		this.SetNextFruit();
	}
	
	// Update is called once per frame
	void Update () {
    if(this.gameManager.getGameState() != GameManager.GameState.Playing) {
      return;
    }

		this.currentTime += Time.deltaTime;
		if(this.currentTime > this.fruitDropTime) {
			this.DropFruit();
			this.currentTime -= this.fruitDropTime;
		}
	}

  public void InitialAction() {
    this.DropFruit();
  }
	
	private void DropFruit() {
		GameObject newFruit = Instantiate(this.nextFruit, this.emitterPosition, this.transform.rotation) as GameObject;
    this.kinectGrabReleaseManager.AddDraggableObject(newFruit);
		this.SetNextFruit();
	}
	
	private void SetNextFruit() {
		int random = Random.Range(0, fruitSamples.Length);
		this.nextFruit = fruitSamples[random];
	}

  public void SteeledFruit(GameObject fruit) {
    this.kinectGrabReleaseManager.RemoveDraggableObject(fruit);
  }

  public void LevelUp(int levelNum) {
    switch (levelNum) {
      case 1: this.fruitDropTime = Const.FRUIT_DROP_SPAN_1; return;
      case 2: this.fruitDropTime = Const.FRUIT_DROP_SPAN_2; return;
      case 3: this.fruitDropTime = Const.FRUIT_DROP_SPAN_3; return;
      default: return;
    }
  }
}
