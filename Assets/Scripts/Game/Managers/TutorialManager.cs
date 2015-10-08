using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : SingletonMono<TutorialManager> {

  public GameObject tutorialPanel;
  public GameObject[] tutorials;
  [SerializeField]
  private int currentPage;

  public void Initialize() {
    for (int i=0; i<this.tutorials.Length; i++) {
      tutorials[i].SetActive(false);
    }
    this.tutorialPanel.SetActive(false);
    this.currentPage = 0;
  }

  public void ShowTutorial() {
    TextStreamer.Instance.WriteFile("Show Tutorial\n");
    this.tutorialPanel.SetActive(true);
    tutorials[this.currentPage].SetActive(true);
    for (int i = 1; i < this.tutorials.Length; i++) {
      tutorials[i].SetActive(false);
    }
    GUIManager.Instance.HideTitle();
  }

  public void NextTutorial() {
    int lastPage = this.currentPage;
    this.currentPage++;

    if (this.currentPage > this.tutorials.Length - 1) {
      this.HideTutorial();
      return;
    }

    this.tutorials[lastPage].SetActive(false);
    this.tutorials[this.currentPage].SetActive(true);
  }

  public void HideTutorial() {
    GUIManager.Instance.Initialize();
    this.Initialize();
  }
}
