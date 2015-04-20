using UnityEngine;
using System.Collections;



public class ActorAI : MonoBehaviour
{
	public int actor_health;
	private string actor_name;
	public float actor_attack;
	public Sprite actor_sprite;
	public GameObject target;
	public float attack_delay = 15;
	public float total_attack_time;
	enum enemy_states{ E_IDLE, E_MOVING, E_WANDER, E_CHASING, E_ATTACKING, E_DEAD};
	enemy_states state;
	public SpriteRenderer sprite;
	
	Animator anim;
	public float sightRadius = 1.8f;
	Vector2 Direction;
	public Vector3 lastSeenLocation;
	public Vector3 targetLocation;
	public bool moving;
	
	int currentWait;
	int waitTrack;
	public float maxMovementSpeed;

	
	public ActorAI(string name, int health, float damage, 
	               Vector3 pos){
		actor_name = name;
		actor_health = health;
		actor_attack = damage;
		transform.position = pos;
	}

	// Use this for initialization
	void Start ()
	{
		total_attack_time = Time.time;
		if (this.gameObject.tag == "Player")
		{

		}

		if (this.gameObject.tag == "Monster")
		{
			sprite = GetComponent<SpriteRenderer>();
			anim = GetComponent<Animator>();
			state = enemy_states.E_IDLE;
			target = GameObject.FindWithTag("Player");
			moving = false;
			if(target == null)
			{
				Debug.Log("No Player Object found");
				
			}
		}
		else {
			Debug.Log ("Actor needs a proper supported tag.");
		}
	}

	// Health functions
	
	void setHealth(int health){
		actor_health = health;
	}
	void takeDamage(int damage){
		actor_health -= damage;
	}
	void heal(int amount){
		actor_health += amount;
	}


	void attack(GameObject p)
	{
		if (Time.time > total_attack_time)
		{
			total_attack_time = Time.time + attack_delay;
			Debug.Log("Attack Player with time");
		}
		//Debug.Log("Player Attacked");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameObject.tag == "Monster"){
			logic();
		}
	}
	
	void logic(){
		this.transform.rotation = Quaternion.identity;
		switch(state){
		case enemy_states.E_IDLE:
			/*
			 * TODO: Add animator functions in here
			 */ 
			
			//Run player detection
			checkSight();
			
			if (state != enemy_states.E_CHASING)
			{
				int newState = Random.Range(1, 11);
				switch (newState)
				{
				case 1:
					state = enemy_states.E_IDLE;
					break;
				case 2:
					state = enemy_states.E_IDLE;
					break;
				case 3:
					state = enemy_states.E_IDLE;
					break;
				case 4:
					state = enemy_states.E_IDLE;
					break;
				case 5:
					state = enemy_states.E_MOVING;
					break;
				case 6:
					state = enemy_states.E_MOVING;
					break;
				case 7:
					state = enemy_states.E_MOVING;
					break;
				case 8:
					state = enemy_states.E_WANDER;
					break;
				case 9:
					state = enemy_states.E_WANDER;
					break;
				case 10:
					state = enemy_states.E_WANDER;
					break;
				}
			}
			break;
		case enemy_states.E_CHASING:
			/*
			 * TODO: Add animator functions in here
			 */
			checkSight();
			
			transform.position = Vector3.Lerp(transform.position, lastSeenLocation, Time.deltaTime*maxMovementSpeed*0.01f);
			if (Vector3.Distance(transform.position, target.transform.position) < 0.36)
			{
				state = enemy_states.E_ATTACKING;
			}
			break;
		case enemy_states.E_MOVING:
			/*
			 * TODO: Add animator functions in here
			 */
			if (!moving)
			{
				int direction = Random.Range(1, 5);
				
				switch (direction)
				{
				case 1:
					targetLocation = transform.position + new Vector3(0, 10, 0);
					break;
				case 2:
					targetLocation = transform.position + new Vector3(0, -10, 0);
					break;
				case 3:
					targetLocation = transform.position + new Vector3(10, 0, 0);
					break;
				case 4:
					targetLocation = transform.position + new Vector3(-10, 0, 0);
					break;
				}
				moving = true;
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, targetLocation, Time.deltaTime * maxMovementSpeed*0.01f);
				
				if (Vector3.Distance(transform.position, targetLocation) < 0.3)
				{
					state = enemy_states.E_IDLE;
					moving = false;
				}
			}
			break;
		case enemy_states.E_WANDER:
			if (!moving)
			{
				int xMovement = Random.Range(-1, 2);
				int yMovement = Random.Range(-1, 2);
				
				targetLocation = transform.position + new Vector3(maxMovementSpeed * xMovement, maxMovementSpeed * yMovement, 0);
				moving = true;
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, targetLocation, Time.deltaTime * maxMovementSpeed*0.01f);
				if (Vector3.Distance(transform.position, targetLocation) < 0.3)
				{
					state = enemy_states.E_IDLE;
					moving = false;
				}
			}
			break;
		case enemy_states.E_ATTACKING:
			/*
			 * TODO: Add animator functions in here
			 */ 
			break;
		case enemy_states.E_DEAD:
			sprite = null;
			
			break;
		}
		
	}
	
	void checkSight(){
		Vector3 tar = target.transform.position;
		float dist = Vector3.Distance(tar, this.transform.position);
//		Debug.Log(dist);
		if ( dist <= sightRadius)
		{

			RaycastHit2D hit = Physics2D.Linecast(this.transform.position,target.transform.position);
			//Debug.Log(hit.transform.position);
			//Debug.Log(target.transform.position);
			if(hit.transform.position == target.transform.position){
				state = enemy_states.E_CHASING;
				lastSeenLocation = hit.transform.position;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
	//	Debug.Log("Monster Collision");

//		moving = false;
//		state = enemy_states.E_IDLE;

	}

	void OnTriggerExit2D(Collider2D other){
		//	Debug.Log("Monster Collision");
		
		logic();

		
	}

	void OnTriggerStay2D(Collider2D other){
		//	Debug.Log("Monster Collision");
		Debug.Log(other.name);

		if (other.gameObject == target)
			Debug.Log(other.name);
		{

				Debug.Log("Set attack!");
				attack(target);

		}

	}
}
