using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Color regular;
	public Color highlight;

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
}
