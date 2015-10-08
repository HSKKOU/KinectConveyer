using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Constants;

public class FruitsManager : SingletonMono<FruitsManager> {

  private GameManager gameManager;
  private KinectGrabReleaseManager kinectGrabReleaseManager;
	
	public GameObject[] fruitSamples;
	private GameObject nextFruit;

  [SerializeField]
  private int[] FRUITS_LEVEL_1 = new int[2];
  private int[] FRUITS_LEVEL_2 = new int[3];
  private int[] FRUITS_LEVEL_3 = {Const.APPLE_NUM, Const.GRAPE_NUM, Const.LEMON_NUM, Const.MELON_NUM, Const.ORANGE_NUM };

  public enum FruitManagerState {
		Init,
		Playing,
		Result
	}
	private FruitManagerState fruitManagerState = FruitManagerState.Init;
	
	private float currentTime;
	private float fruitDropTime = Const.FRUIT_DROP_SPAN[0];
  private int[] fruitsList;

	[SerializeField]
	private Vector3 emitterPosition;
	
	public void Initialize() {
    this.DestroyAllFruits();
    this.SetFruitLevel();

    this.gameManager = GameManager.Instance;
    this.kinectGrabReleaseManager = KinectGrabReleaseManager.Instance;
    this.fruitDropTime = Const.FRUIT_DROP_SPAN[0];
    this.fruitsList = FRUITS_LEVEL_1;
		this.currentTime = 0.0f;
		this.SetNextFruit();
	}

  private void SetFruitLevel() {
    this.FRUITS_LEVEL_1 = this.SetFruitList(2);
    this.FRUITS_LEVEL_2 = this.SetFruitList(3);
  }

  private int[] SetFruitList(int num) {
    int[] retList = new int[num];
    List<int> fns = new List<int> { Const.APPLE_NUM, Const.GRAPE_NUM, Const.LEMON_NUM, Const.MELON_NUM, Const.ORANGE_NUM };
    for (int i = 0; i < num; i++) {
      retList[i] = fns[Random.Range(0, fns.Count)];
      fns.Remove(retList[i]);
    }
    return retList;
  }

  private void DestroyAllFruits() {
    GameObject[] gos = GameObject.FindGameObjectsWithTag(Const.FRUIT_TAG);
    foreach(GameObject g in gos) {
      Destroy(g);
    }
    gos = GameObject.FindGameObjectsWithTag(Const.GRABBED_FRUIT_TAG);
    foreach (GameObject g in gos)
    {
      Destroy(g);
    }
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
		int random = Random.Range(0, fruitsList.Length);
		this.nextFruit = fruitSamples[fruitsList[random]];
	}

  public void SteeledFruit(GameObject fruit) {
    this.kinectGrabReleaseManager.RemoveDraggableObject(fruit);
  }

  public void LevelUp(int levelNum) {
    this.fruitDropTime = Const.FRUIT_DROP_SPAN[levelNum - 1];

    switch (levelNum) {
      case 1: this.fruitsList = this.FRUITS_LEVEL_1; return;
      case 2: this.fruitsList = this.FRUITS_LEVEL_2; return;
      case 3: this.fruitsList = this.FRUITS_LEVEL_3; return;
      default: return;
    }
  }
}
