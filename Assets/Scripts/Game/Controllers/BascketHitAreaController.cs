using UnityEngine;
using System.Collections;

using Constants;

public class BascketHitAreaController : MonoBehaviour {

  [SerializeField]
  private string fruitName;

  private BascketHitManager bascketHitManager;

  void Start() {
    this.bascketHitManager = BascketHitManager.Instance;
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag != Const.RELEASED_FRUIT_TAG) {
      Destroy(other.gameObject);
      return;
    }

    FruitController fc = other.gameObject.GetComponent<FruitController>();
    if(fc.getFruitName() == this.fruitName) {
      TextStreamer.Instance.WriteFile("BascketHitAreaController: SUCCESS, " + this.fruitName + "\n");
      this.bascketHitManager.GetFruit();
    } else {
      TextStreamer.Instance.WriteFile("BascketHitAreaController: FAILED, " + this.fruitName + "\n");
      this.bascketHitManager.GetIncorrectFruit();
    }

    Destroy(other.gameObject);
  }
}
