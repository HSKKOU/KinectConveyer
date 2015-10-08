using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : SingletonMono<ScoreManager> {
	
	[SerializeField]
	private Text scoreText;

  [SerializeField]
  private Text resultText;
  [SerializeField]
  private Text top3Text;

  private GameManager gameManager;
	
	private int score = 0;
	public int getScore(){return this.score;}

	public void Initialize() {
    this.gameManager = GameManager.Instance;
    this.score = 0;
		this.UpdateScore();
	}
	
	private void UpdateScore() {
    if(this.gameManager.getGameState() != GameManager.GameState.Init && this.gameManager.getGameState() != GameManager.GameState.Playing) {
      return;
    }
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

  public void ShowResult() {
    this.resultText.text = this.score + "";
    this.top3Text.text = "100\n100\n100\n";
    GUIManager.Instance.ShowResult();
  }
}
