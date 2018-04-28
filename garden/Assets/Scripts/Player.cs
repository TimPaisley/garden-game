using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public NavMeshAgent agent;
	public ThirdPersonCharacter character;
	public Rigidbody rigidbody;

	private Queue<IAction> actions;
	private IAction activeAction;

	void Start () {
		agent.updateRotation = false;
		actions = new Queue<IAction>();
	}

	void Update () {
		MovePlayer();

		if (activeAction != null) {
			RunAction (activeAction);
		}

		if (activeAction == null && actions.Count > 0) {
			IAction nextAction = actions.Dequeue();
			activeAction = nextAction;
			activeAction.Begin ();
		}
	}

	private void RunAction(IAction action) {
		if (!action.InProgress ()) {
			action.Complete ();
			activeAction = null;
		}
	}

	private void MovePlayer() {
		if(agent.remainingDistance > agent.stoppingDistance) {
			character.Move(agent.desiredVelocity, false, false);
		} else {
			character.Move(Vector3.zero, false, false);
		}
	}

	public void AddMoveAction(Vector3 point) {
		actions.Enqueue(new Move(agent, character, point));
	}

	public void AddPlantAction(Tile tile, Plant plant) {
		actions.Enqueue (new Move (agent, character, tile.transform.position));
		actions.Enqueue (new Sow (tile, plant, 2f, GetComponent<Animator>()));
	}
}
