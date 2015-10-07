using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Constants;

public class TimerManager : SingletonMono<TimerManager> {
	
	private GameManager gameManager;

	[SerializeField]
	private Text timerText;
	
	private float currentTime;
	private float restTime;
	
	public void Initialize() {
		this.gameManager = GameManager.Instance;
		this.currentTime = 0.0f;
		this.restTime = Const.DEFAULT_INIT_TIME;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameManager.getGameState() == GameManager.GameState.Playing) {
			this.UpdateTime();
		}
	}
	
	private void UpdateTime() {
			this.currentTime += Time.deltaTime;
			if(this.restTime <= this.currentTime) {
				this.TimeOver();
			}
			this.timerText.text = "" + (this.restTime - Mathf.Floor(this.currentTime));
	}
	
	private void TimeOver() {
		this.gameManager.GameOver();
	}
}
