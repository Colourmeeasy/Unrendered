using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {
    private TrailRenderer trail;
	// Use this for initialization
	void Start () {
        trail = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance)) {
                this.transform.position = mRay.GetPoint(rayDistance);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            GameObject obj = new GameObject();
            MeshFilter filter = obj.AddComponent<MeshFilter>();
            Mesh mesh = filter.mesh;
            int count = ((int)trail.positionCount / 3) * 3;
            Vector3[] vertices = new Vector3[count];
            Vector2[] uvs = new Vector2[count];
            int[] triangles = new int[count];
            for (int i = 0; i < count; i++)
            {
                Vector3 position = trail.GetPosition(i);
                vertices[i] = position;
                uvs[i] = new Vector2(position.x, position.z);
                if (i > 0 && i % 3 == 0) {
                    triangles[i - 2] = 0;
                    triangles[i - 1] = i - 1;
                    triangles[i] = i;
                }

            }
            mesh.vertices = vertices;
            mesh.uv = uvs;
            mesh.triangles = triangles;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();
            MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
            BoxCollider box = obj.AddComponent<BoxCollider>();
            //MeshCollider collider = obj.AddComponent<MeshCollider>();
            Rigidbody rigidbody = obj.AddComponent<Rigidbody>();
            //rigidbody.isKinematic = true;
            trail.Clear();
        }
	}
}
