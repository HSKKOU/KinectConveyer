using UnityEngine;
using System.Collections;

public class ConveyerController : SingletonMono<ConveyerController> {
  
  private float conveyerSpeed;
  public float getConveyerSpeed(){return this.conveyerSpeed;}
  public void setConveyerSpeed(float cs){this.conveyerSpeed = cs;}

  // Use this for initialization
  void Start() {
      
  }

  // Update is called once per frame
  void Update() {

  }
}
