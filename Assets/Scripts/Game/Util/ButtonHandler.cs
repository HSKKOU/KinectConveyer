using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
  
  public void OnClick() {
    GameManager.Instance.GameStart();
  }

  public void OnRetry() {
    GameManager.Instance.Retry();
  }

  public void OnTutorial() {
    GameManager.Instance.Tutorial();
  }

  public void NextTutorial() {
    TutorialManager.Instance.NextTutorial();
  }
}
