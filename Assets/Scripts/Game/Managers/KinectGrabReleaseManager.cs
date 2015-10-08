using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Constants;

public class KinectGrabReleaseManager : SingletonMono<KinectGrabReleaseManager> {
  [Tooltip("List of the objects that may be dragged and dropped.")]
  public List<GameObject> draggableObjects;

  [Tooltip("Speed of dragging of the selected object.")]
  public float dragSpeed = 3.0f;

  // public options (used by the Options GUI)
  [Tooltip("Whether the objects obey gravity when released or not. Used by the Options GUI-window.")]
  public bool useGravity = true;


  // interaction manager reference
  private InteractionManager manager;
  private bool isLeftHandDrag;

  // currently dragged object and its parameters
  private GameObject draggedObject;
  private Vector3 draggedObjectOffset;


  public void Initialize() {

  }

  void Update()
  {
    // get the interaction manager instance
    if (manager == null)
    {
      manager = InteractionManager.Instance;
    }

    if (manager != null && manager.IsInteractionInited())
    {
      Vector3 screenNormalPos = Vector3.zero;
      Vector3 screenPixelPos = Vector3.zero;

      if (draggedObject == null)
      {
        // if there is a hand grip, select the underlying object and start dragging it.
        if (manager.IsLeftHandPrimary())
        {
          // if the left hand is primary, check for left hand grip
          if (manager.GetLastLeftHandEvent() == InteractionManager.HandEventType.Grip)
          {
            isLeftHandDrag = true;
            screenNormalPos = manager.GetLeftHandScreenPos();
          }
        }
        else if (manager.IsRightHandPrimary())
        {
          // if the right hand is primary, check for right hand grip
          if (manager.GetLastRightHandEvent() == InteractionManager.HandEventType.Grip)
          {
            isLeftHandDrag = false;
            screenNormalPos = manager.GetRightHandScreenPos();
          }
        }

        // check if there is an underlying object to be selected
        if (screenNormalPos != Vector3.zero)
        {
          // convert the normalized screen pos to pixel pos
          screenPixelPos.x = (int)(screenNormalPos.x * Camera.main.pixelWidth);
          screenPixelPos.y = (int)(screenNormalPos.y * Camera.main.pixelHeight);

          Vector2 point = Camera.main.ScreenToWorldPoint(screenPixelPos);
          Collider2D collision2d = Physics2D.OverlapPoint(point);
          
          if (collision2d) {
            RaycastHit2D hit = Physics2D.Raycast(point, -Vector2.up);
            if (hit) {
              foreach (GameObject obj in draggableObjects) {
                if (hit.collider.gameObject == obj)
                {
                  // an object was hit by the ray. select it and start drgging
                  draggedObject = obj;
                  draggedObject.GetComponent<FruitController>().OnGrabbedKinect();
                  Vector2 draggedObjectPos = new Vector2(draggedObject.transform.position.x, draggedObject.transform.position.y);
                  draggedObjectOffset = hit.point - draggedObjectPos;
                  break;
                }
              }
            }
          }
        }
      } else {
        // continue dragging the object
        screenNormalPos = isLeftHandDrag ? manager.GetLeftHandScreenPos() : manager.GetRightHandScreenPos();

        // convert the normalized screen pos to 3D-world pos
        screenPixelPos.x = (int)(screenNormalPos.x * Camera.main.pixelWidth);
        screenPixelPos.y = (int)(screenNormalPos.y * Camera.main.pixelHeight);

        if (screenPixelPos.y < Camera.main.pixelHeight / 4) {
          screenPixelPos.y = Camera.main.pixelHeight / 4;
        }

        Vector2 newObjectPos = Camera.main.ScreenToWorldPoint(screenPixelPos) - draggedObjectOffset;
        draggedObject.transform.position = Vector3.Lerp(draggedObject.transform.position, newObjectPos, dragSpeed * Time.deltaTime);

        // check if the object (hand grip) was released
        bool isReleased = isLeftHandDrag ? (manager.GetLastLeftHandEvent() == InteractionManager.HandEventType.Release) :
          (manager.GetLastRightHandEvent() == InteractionManager.HandEventType.Release);

        if (isReleased) {
          draggedObject.GetComponent<FruitController>().OnReleasedKinect();
          draggedObject = null;
        }
      }
    }
  }

  public void AddDraggableObject(GameObject obj) {
    this.draggableObjects.Add(obj);
  }

  public void RemoveDraggableObject(GameObject obj) {
    this.draggableObjects.Remove(obj);
  }
}
