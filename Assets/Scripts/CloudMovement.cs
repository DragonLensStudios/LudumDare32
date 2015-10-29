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
	private GameObject Enemy;



	public EnemyisHit Enemy_Hit;



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


	void Start () {
		mousePosition = transform.position;
		cloudDamageExplosion = 3;
		cloudDamageTornado = 2;
		cloudDamageWater = 4;
		cloudDamageLightning = 5;
	}

	void Update () {
			
		if(movingCloud == true && !atplayer) {

			Pos = target.position;
			Pos.x = target.position.x;
			Pos.y = target.position.y;
			horizontalSpeed = 2.0f;
			verticalSpeed = 2.0f;
			float h = horizontalSpeed * Input.GetAxis ("Horizontal");
			float y = verticalSpeed * Input.GetAxis ("Vertical");
			iTween.MoveUpdate (gameObject, iTween.Hash ("position", Pos + Vector3.left * h, "time", 1.0f, "easetype", "linear", "oncomplete", "CloudMoveComplete"));
			iTween.MoveUpdate (gameObject, iTween.Hash ("position", Pos + Vector3.down * y, "time", 1.0f, "easetype", "linear", "oncomplete", "CloudMoveComplete"));
		}

		if (Input.GetButton ("Fire2")) {
			movingCloud = false;
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			iTween.MoveTo (gameObject, iTween.Hash ("position", mousePosition, "time", 1.0f, "easetype", "linear", "looptype", "none"));

		} else {
			movingCloud = true;
		}

		if (Input.GetKeyDown ("1")) {
			
			if(genClone == null){
				genClone = (GameObject) Instantiate(tornado, transform.position, transform.rotation);
				Destroy(genClone, 2f);
				GetComponents<AudioSource>()[3].Play();
				Enemy_Hit.health -= cloudDamageTornado;
			}

			


		}

		if (Input.GetKeyDown ("2")) {
			
			if(genClone == null){
				genClone = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
				Destroy(genClone, 2f);
				GetComponents<AudioSource>()[0].Play();
				Enemy_Hit.health -= cloudDamageExplosion;
			}




		}

		if (Input.GetKeyDown ("3")) {
			
			if(genClone == null){
				genClone = (GameObject) Instantiate(water, transform.position, transform.rotation);
				Destroy(genClone, 2f);
				GetComponents<AudioSource>()[2].Play();
				Enemy_Hit.health -= cloudDamageWater;

			}

		}

		if (Input.GetKeyDown ("4")) {
			
			if(genClone == null){
				genClone = (GameObject) Instantiate(lightning, transform.position, transform.rotation);
				Destroy(genClone, 2f);
				GetComponents<AudioSource>()[1].Play();
				Enemy_Hit.health -= cloudDamageLightning;
			}

		}



	
	}







	void CloudMoveComplete(){
		Debug.Log ("The cloud is done moving");
	}



	void OnTriggerExit2D(Collider2D col){
		{
			
			
			Enemy_Hit = null;

			
			if(col.tag == "Player"){
				atplayer = false;
			}
			
		}
	}


	void OnGUI(){
		if (Enemy_Hit) {
			GUI.Box (new Rect (375, 2, Screen.width / 5 / (Enemy_Hit.maxHealth / Enemy_Hit.health), 36), " ");
			GUI.Box (new Rect (375, 2, Screen.width / 5, 36), Enemy_Hit.name + " Health: " + Enemy_Hit.health + "/" + Enemy_Hit.maxHealth);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{	
		Enemy_Hit = col.gameObject.GetComponent<EnemyisHit> ();
		if (Enemy_Hit) {
			if (Enemy_Hit.health < 1) {
				Enemy_Hit.health = 0;
			}
		}

		


		if(col.tag == "Player"){
			atplayer = true;
		}






	}


	void DestroyAnimation()
	{
		Destroy (gameObject);
	}


}