using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera cam;
	public Player player;
	public LayerMask raycastLayers;
	public Plant plant;

	[HideInInspector]
	public Tile tileInFocus;
	
	void Update () {
		FireRaycast();
	}

	private void FireRaycast() {
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayers)) {
			HandleHit(hit);
		}
	}

	private void HandleHit (RaycastHit hit) {
		if (hit.transform.GetComponent<Tile>()) {
			Tile tile = hit.transform.GetComponent<Tile>();
			tileInFocus = tile;

			if (Input.GetMouseButtonDown(0)) {
				if (Input.GetKey (KeyCode.W) && !tile.planted) {
					player.AddPlantAction(tile, plant);
				} else {
					player.AddMoveAction(hit.point);
				}
			}
		}
	}
}
