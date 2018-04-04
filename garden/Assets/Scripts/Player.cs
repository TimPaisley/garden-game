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
			RunAction2(activeAction);
			Debug.Log ("Performing Action");
		}

		if (activeAction == null && actions.Count > 0) {
			IAction nextAction = actions.Dequeue();
			activeAction = nextAction;
			activeAction.Begin ();
			Debug.Log ("Action Started");
		}

	}

	private void RunAction2(IAction action) {
		if (!action.InProgress ()) {
			action.Complete ();
			activeAction = null;
			Debug.Log ("Action Finished");
		}
	}

//	private IEnumerator RunAction(IAction action) {
//		agent.SetDestination(action.destination);
//		Debug.Log ("Starting Action");
//		int i = 0;
//
//		while(action.state != Action.State.Finished || i < 10000) {
//			if (action.state == Action.State.Moving) {
//				Debug.Log ("Action: Moving");
//				if (agent.remainingDistance > agent.stoppingDistance) {
//					Debug.Log ("Action: Moving -> Acting");
//					action.state = Action.State.Acting;
//				}
//			} else if (action.state == Action.State.Acting) {
//				Debug.Log ("Action: Acting");
//				yield return new WaitForSeconds(action.duration);
//				Debug.Log ("Action: Acting -> Finished");
//				action.state = Action.State.Finished;
//			}
//
//			i++;
//		}
//
//		activeAction = null;
//		Debug.Log ("Action: Finished");
//		yield return new WaitForSeconds(0.2f);
//	}
//
	private void MovePlayer() {
		if(agent.remainingDistance > agent.stoppingDistance) {
			character.Move(agent.desiredVelocity, false, false);
		} else {
			character.Move(Vector3.zero, false, false);
		}
	}

	public void AddDestination(Vector3 point) {
		actions.Enqueue(new Move(character, agent, point, rigidbody));
	}
}
