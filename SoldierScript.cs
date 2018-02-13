using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour {
	private GameObject player;
	public NPC npc;
	public Objectmovement playerStats;
	public DialogueManager continuation;


	private int engaged;
	private int random;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		random = 0;
		engaged = 0;
	}
	// Update is called once per frame
	void Update () 
	{
		if (player.transform.position.x >= -274 && player.transform.position.x <= -250 && engaged == 0) 
		{
			npc.TriggerDialogue ();
			engaged = 1;
		} 
		else if (player.transform.position.x >= -249 && player.transform.position.x <= -200 && engaged == 1) 
		{
			continuation.DisplayNextSentence ();
			engaged = 2;
		}
		else if (player.transform.position.x >= -199 && player.transform.position.x <= -175 && engaged == 2) 
		{
			continuation.DisplayNextSentence ();
			engaged = 3;
		}
		else if (player.transform.position.x >= -174 && player.transform.position.x <= -150 && engaged == 3) 
		{
			continuation.DisplayNextSentence ();
			engaged = 4;
		}
		else if (player.transform.position.x >= -149 && player.transform.position.x <= -100 && engaged == 4) 
		{
			
			StartCoroutine (shotsFired ());

			engaged = 5;
		}

	}

	IEnumerator shotsFired()
	{
		continuation.EndDialogue ();
		for (int n = 0; n < 4; n++) 
		{
			random = Random.Range (1, 4);
			Debug.Log (random);
			if (random == 1) {
				playerStats.PlayerHealthState (1);
				n = 12;
			}
			yield return new WaitForSeconds (3f);

		
		}
	}

	public void PlayerLose()
	{
		player.transform.position = new Vector2 (-500, 50);
	}
}
