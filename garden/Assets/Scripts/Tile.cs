using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Color regular;
	public Color highlight;
	public bool planted;

	private GameManager manager;
	private Renderer rend;

	void Start () {
		manager = FindObjectOfType<GameManager>();
		rend = GetComponent<Renderer>();
		
		rend.material.color = regular;
	}

	void Update () {
		if (manager.tileInFocus == this) {
			rend.material.color = highlight;
		} else {
			rend.material.color = regular;
		}
	}

	public void Sow (Plant plant) {
		planted = true;
		Instantiate (plant.gameObject, this.transform.position + Vector3.up, Quaternion.identity, this.transform);
	}
}
