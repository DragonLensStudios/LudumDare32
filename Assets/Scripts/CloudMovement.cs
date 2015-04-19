using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public GameObject explosion;
	private GameObject explosionClone;

	public bool movingCloud;
	public Transform target;
	bool top, right, left, bottom;
	public float horizontalSpeed;
	public float verticalSpeed;
	private Vector3 Pos;
	private Vector3 mousePosition;
	// Use this for initialization
	void Start () {
		mousePosition = transform.position;


	}
	
	// Update is called once per frame
	void Update () {

		if(movingCloud == true) {

			Pos = target.position;
			Pos.x = target.position.x;
			Pos.y = target.position.y;
			horizontalSpeed = 2.0f;
			verticalSpeed = 2.0f;
			float h = horizontalSpeed * Input.GetAxis ("Mouse X");
			float y = verticalSpeed * Input.GetAxis ("Mouse Y");
			iTween.MoveUpdate (gameObject, iTween.Hash ("position", Pos + Vector3.right * h, "time", 1.5f, "easetype", "linear", "oncomplete", "CloudMoveComplete"));
			iTween.MoveUpdate (gameObject, iTween.Hash ("position", Pos + Vector3.down * y, "time", 1.5f, "easetype", "linear", "oncomplete", "CloudMoveComplete"));
		}
		
		if (Input.GetButton ("Fire2")) {
			movingCloud = false;
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			iTween.MoveTo (gameObject, iTween.Hash ("position", mousePosition, "time", 2.5f, "easetype", "linear"));
		} else {
			movingCloud = true;
		}




		if (Input.GetKeyDown ("1")) {

			explosionClone = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy(explosionClone);
		}






}

	void CloudMoveComplete(){
		Debug.Log ("The cloud is done moving");
	}



}
