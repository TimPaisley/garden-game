using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract public class Action {
//	public enum State { Moving, Acting, Finished };
//
//	public State state;
//	public Vector3 destination;
//	public float duration;
//
//	public Action(Vector3 destination, float duration) {
//		this.state = State.Moving;
//		this.destination = destination;
//		this.duration = duration;
//	}
//
//	// Move
//}

interface IAction {
	void Begin();
	bool InProgress();
	void Process(float duration);
	void Complete ();
}