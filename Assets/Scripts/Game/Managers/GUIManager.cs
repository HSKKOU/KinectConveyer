using UnityEngine;
using System.Collections;

public class GUIManager : SingletonMono<GUIManager> {

  public GameObject GUI;
  public GameObject TitlePanel;
  public GameObject ResultPanel;

  public void Initialize() {
    TitlePanel.SetActive(true);
    ResultPanel.SetActive(false);
  }

  public void HideTitle() {
    TitlePanel.SetActive(false);
  }

  public void ShowResult() {
    ResultPanel.SetActive(true);
  }
}
