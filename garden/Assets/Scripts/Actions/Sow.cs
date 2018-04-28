using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Sow : IAction {

	private Tile tile;
	public Plant plant;
	private float plantDuration;
	private Animator anim;

	public Sow(Tile tile, Plant plant, float plantDuration, Animator anim) {
		this.tile = tile;
		this.plant = plant;
		this.plantDuration = plantDuration;
		this.anim = anim;
	}

	public void Begin() {
		
	}

	public bool InProgress() {
		plantDuration -= Time.deltaTime;

		if (anim) {
			anim.SetBool ("Crouch", true);
		}

		if (plantDuration <= 0) {
			return false;
		}

		return true;
	}

	public void Process() {
		Debug.Log (plantDuration);
		plantDuration -= Time.deltaTime;
	}

	public void Complete() {
		tile.Sow (plant);

		if (anim) {
			anim.SetBool ("Crouch", false);
		}
	}
}
