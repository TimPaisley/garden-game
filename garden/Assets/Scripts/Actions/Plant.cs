using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Plant : IAction {

	private Tile tile;
	private GameObject plant;

	public Plant(Tile tile, GameObject plant) {
		this.tile = tile;
		this.plant = plant;
	}

	public void Begin() {
		
	}

	public bool InProgress() {
		return false;
	}

	public void Process(float duration) {
		
	}

	public void Complete() {
		
	}
}
