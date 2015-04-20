using UnityEngine;
using System.Collections;



public class Monster : MonoBehaviour
{
	int m_Health;
	string m_Name;
	float m_Attack;
	Sprite m_Sprite;
	GameObject target;
	enum enemy_states{ E_IDLE, E_MOVING, E_WANDER, E_CHASING, E_ATTACKING, E_DEAD};
	enemy_states state;
	public SpriteRenderer sprite;
	
	Animator anim;
	public float sightRadius;
	Vector2 Direction;
	public Vector3 lastSeenLocation;
	public Vector3 targetLocation;
	bool moving;
	
	int currentWait;
	int waitTrack;
	float maxMovementSpeed;
	
	public Monster(string name, int health, float damage, 
	               Vector3 pos){
		m_Name = name;
		m_Health = health;
		m_Attack = damage;
		transform.position = pos;
	}
	
	// Health functions
	
	void setHealth(int health){
		m_Health = health;
	}
	void takeDamage(int damage){
		m_Health -= damage;
	}
	void heal(int amount){
		m_Health += amount;
	}
	
	void attack(Player p){ //
	}
	
	// Use this for initialization
	void Start ()
	{
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		state = enemy_states.E_IDLE;
		target = GameObject.FindWithTag("Player");
		sightRadius = 1.8f;
		maxMovementSpeed = 5.0f;
		moving = false;

		if(target == null)
			Debug.Log("No Player Object found");
	}
	
	// Update is called once per frame
	void Update ()
	{
		logic();
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

	void OnCollisionEnter2D(Collision2D other){
	//	Debug.Log("Monster Collision");
		moving = false;
		state = enemy_states.E_IDLE;
	}
}
