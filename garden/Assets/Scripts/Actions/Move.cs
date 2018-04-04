using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Move : IAction {

	private NavMeshAgent agent;
	private ThirdPersonCharacter character;
	private Vector3 destination;
	private Rigidbody rigidbody;

	public Move(ThirdPersonCharacter character, NavMeshAgent agent, Vector3 destination, Rigidbody rigidbody) {
		this.agent = agent;
		this.character = character;
		this.destination = destination;
		this.rigidbody = rigidbody;
	}

	public void Begin() {
		agent.SetDestination (destination);
	}

	public bool InProgress() {
		return agent.remainingDistance > agent.stoppingDistance;
	}

	public void Process(float duration) {
		character.Move(agent.desiredVelocity, false, false);
	}

	public void Complete() {
		character.Move(Vector3.zero, false, false);
	}
}
