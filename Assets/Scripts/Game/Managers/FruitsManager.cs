using UnityEngine;
using System.Collections;

public class FruitsManager : SingletonMono<FruitsManager> {
	
	public GameObject[] fruitSamples;
	private GameObject nextFruit;
	
	public enum FruitManagerState {
		Init,
		Playing,
		Result
	}
	private FruitManagerState fruitManagerState = FruitManagerState.Init;
	
	private float currentTime;
	private const float FRUIT_DROP_TIME = 2.0f;

	[SerializeField]
	private Vector3 emitterPosition;
	
	public void Initialize() {
		this.currentTime = 0.0f;
		this.SetNextFruit();
	}
	
	// Update is called once per frame
	void Update () {
		this.currentTime += Time.deltaTime;
		if(this.currentTime > FRUIT_DROP_TIME) {
			this.DropFruit();
			this.currentTime -= FRUIT_DROP_TIME;
		}
	}
	
	private void DropFruit() {
		Instantiate(this.nextFruit, this.emitterPosition, this.transform.rotation);
		this.SetNextFruit();
	}
	
	private void SetNextFruit() {
		int random = Random.Range(0, fruitSamples.Length);
		this.nextFruit = fruitSamples[random];
	}
}
