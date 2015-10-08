using UnityEngine;
using System.Collections;

public class GUIManager : SingletonMono<GUIManager> {

  public GameObject GUI;
  public GameObject TitlePanel;

  public void Initialize() {
    TitlePanel.SetActive(true);
  }

  public void HideTitle() {
    TitlePanel.SetActive(false);
  }
}
