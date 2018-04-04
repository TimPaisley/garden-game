using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera cam;
	public Player player;
	public LayerMask raycastLayers;

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
				player.AddDestination(hit.point);
			}
		}
	}
}
