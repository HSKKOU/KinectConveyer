using UnityEngine;
using System.Collections;

public class ThiefController : MonoBehaviour {

	[SerializeField]
	private GameObject handImage;

	// Use this for initialization
	void Start () {
		this.handImage.SetActive(false);
	}
	
	public void SteelFruit(){
		this.handImage.SetActive(true);
		StartCoroutine("HideHand");
	}
	
	private IEnumerator HideHand() {
		yield return new WaitForSeconds(0.5f);
		Debug.Log("hide");
		this.handImage.SetActive(false);
	}
}
