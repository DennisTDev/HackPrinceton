using UnityEngine;

public class CloudCluster : MonoBehaviour {
	public GameObject[] clouds;
	public Material[] materials;
	public float[] sizes;

	public void Spawn (int count, Vector3 position, int radius, int deltaY) {
		for (int i = 0; i < count; i++) {
			GameObject cloud = clouds[i % clouds.Length];
			Vector2 p = Random.insideUnitCircle * radius;
			position.x += p.x;
			position.y += Random.Range(-deltaY, deltaY);
			position.z += p.y;
			Quaternion rotation = Random.rotation;
			cloud = Instantiate(cloud, position, rotation);
			Renderer renderer = cloud.GetComponent<Renderer>();
			renderer.material = materials[i % materials.Length];
			cloud.transform.parent = transform;
			float s = sizes[i % sizes.Length];
			cloud.transform.localScale = new Vector3(s, s, s);
		}
	}
}
