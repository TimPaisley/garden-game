using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Move : IAction {

	private NavMeshAgent agent;
	private ThirdPersonCharacter character;
	private Vector3 destination;

	public Move(NavMeshAgent agent, ThirdPersonCharacter character, Vector3 destination) {
		this.agent = agent;
		this.character = character;
		this.destination = destination;
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
