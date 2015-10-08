using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : SingletonMono<ScoreManager> {
	
	[SerializeField]
	private Text scoreText;
	
	private int score = 0;
	public int getScore(){return this.score;}

	public void Initialize() {
		this.UpdateScore();
	}
	
	private void UpdateScore() {
		this.scoreText.text = "" + this.score;
	}
	
	public void Plus(int num) {
    if (this.score + num < 0) {
      this.score = 0;
    } else {
      this.score += num;
    }
    this.UpdateScore();
	}
	
	public void Minus(int num) {
		if(this.score < num) {
			this.score = 0;
		} else {
			this.score -= num;
		}
		this.UpdateScore();
	}
}
