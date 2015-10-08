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

  private int[] top3s = { 0, 0, 0 };

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
    TextStreamer.Instance.WriteFile("score: " + this.score);
    this.UpdateHighScore();
    this.top3Text.text = this.top3s[0] + "\n" + this.top3s[1] + "\n" + this.top3s[2] + "\n";
    GUIManager.Instance.ShowResult();
  }

  private void UpdateHighScore() {
    for (int i=0; i<this.top3s.Length; i++) {
      if (this.top3s[i] < this.score) {
        int newScore = this.score;
        for (int j= i; j<this.top3s.Length; j++) {
          int tmp = this.top3s[j];
          this.top3s[j] = newScore;
          newScore = tmp;
        }
        break;
      }
    }
  }
}
