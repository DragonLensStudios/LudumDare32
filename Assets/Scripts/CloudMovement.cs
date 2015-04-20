using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public GameObject explosion;
	public GameObject tornado;
	public GameObject water;
	public GameObject lightning;


	public bool movingCloud;
	public bool atplayer;
	public Transform target;
	bool top, right, left, bottom;
	public float horizontalSpeed;
	public float verticalSpeed;
	private Vector3 Pos;
	private Vector3 mousePosition;
	private GameObject Slime;
	public SlimeisHit Slime_Hit;
	public int cloudDamageExplosion;
	
	public int cloudDamageTornado;
	
	public int cloudDamageWater;
	
	public int cloudDamageLightning;
	public bool isAttacking;
	public bool isColliding;


	private GameObject genClone;
	private GameObject tornadoClone;
	private GameObject ExplosionClone;
	private GameObject WaterClone;
	private GameObject LightningClone;


	// Use this for initialization
	void Start () {
		mousePosition = transform.position;
		cloudDamageExplosion = 3;
		cloudDamageTornado = 2;
		cloudDamageWater = 4;
		cloudDamageLightning = 5;
	}

	// Update is called once per frame
	void Update () {

		if(movingCloud == true && !atplayer) {

			Pos = target.position;
			Pos.x = target.position.x;
			Pos.y = target.position.y;
			horizontalSpeed = 2.0f;
			verticalSpeed = 2.0f;
			float h = horizontalSpeed * Input.GetAxis ("Horizontal");
			float y = verticalSpeed * Input.GetAxis ("Vertical");
			iTween.MoveUpdate (gameObject, iTween.Hash ("position", Pos + Vector3.left * h, "time", 1.5f, "easetype", "linear", "oncomplete", "CloudMoveComplete"));
			iTween.MoveUpdate (gameObject, iTween.Hash ("position", Pos + Vector3.down * y, "time", 1.5f, "easetype", "linear", "oncomplete", "CloudMoveComplete"));
		}
		
		if (Input.GetButton ("Fire2")) {
			movingCloud = false;
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			iTween.Stop(gameObject);

			iTween.MoveTo (gameObject, iTween.Hash ("position", mousePosition, "time", 2.5f, "easetype", "linear"));
		} else {
			movingCloud = true;
		}

		if (Input.GetKeyDown ("1")) {
			
			//explosionClone = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
			//Instantiate (tornado, transform.position, Quaternion.identity);
			if(genClone == null){
				genClone = (GameObject) Instantiate(tornado, transform.position, transform.rotation);
				Destroy(genClone, .8f);
			}


			//if(explosionClone = this.transform.position);

		}

		if (Input.GetKeyDown ("2")) {
			
			//explosionClone = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
			if(genClone == null){
				genClone = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
				Destroy(genClone, 1f);
			}
			//if(explosionClone = this.transform.position);
			
		}

		if (Input.GetKeyDown ("3")) {
			
			//explosionClone = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
			if(genClone == null){
				genClone = (GameObject) Instantiate(water, transform.position, transform.rotation);
				Destroy(genClone, .5f);
			}
			//if(explosionClone = this.transform.position);
			
		}

		if (Input.GetKeyDown ("4")) {
			
			//explosionClone = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
			if(genClone == null){
				genClone = (GameObject) Instantiate(lightning, transform.position, transform.rotation);
				Destroy(genClone, 3f);
			}
			//if(explosionClone = this.transform.position);
			
		}



	
	}







	void CloudMoveComplete(){
		Debug.Log ("The cloud is done moving");
	}


	void OnTriggerEnter2D(Collider2D col){
		{


			Slime_Hit = col.gameObject.GetComponent<SlimeisHit> ();

			if(col.tag == "Player"){
				Debug.Log("stopping");
				atplayer = true;
			}
				//Destroy(explosionClone);
		
		}
	}

	void OnTriggerExit2D(Collider2D col){
		{
			
			
			Slime_Hit = null;
			
			if(col.tag == "Player"){
				Debug.Log("moving");
				atplayer = false;
			}
			//Destroy(explosionClone);
			
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{	
		if (Input.GetKeyDown ("1")) { 
				Slime_Hit.health -= cloudDamageTornado;
			}
		if (Input.GetKeyDown ("2")) { 
			Slime_Hit.health -= cloudDamageExplosion;
		}
		if (Input.GetKeyDown ("3")) { 
			Slime_Hit.health -= cloudDamageWater;
		}
		if (Input.GetKeyDown ("4")) { 
			Slime_Hit.health -= cloudDamageLightning;
		}

	}


	void DestroyAnimation()
	{
		Destroy (gameObject);
	}
}