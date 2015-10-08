using UnityEngine;
using System.Collections;

using Constants;

public class BascketHitManager : SingletonMono<BascketHitManager> {

  private ScoreManager scoreManager;
  private int sequencialCorrectNum = 0;

  public void Initialize() {
    this.scoreManager = ScoreManager.Instance;
    this.sequencialCorrectNum = 0;
  }
	
  public void GetFruit() {
    sequencialCorrectNum++;
    this.UpdateScore(Const.DEFAULT_PLUS_POINT);
  }

  public void GetIncorrectFruit() {
    sequencialCorrectNum = 0;
    this.UpdateScore(Const.DEFAULT_MINUS_POINT);
  }

  private void UpdateScore(int defScore) {
    int score = defScore;
    int bonus = Const.BONUS_UNIT * (this.sequencialCorrectNum / Const.COUNT_BONUS_UP);
    this.scoreManager.Plus(score + bonus);
  }
}
