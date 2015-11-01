using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaTerrain : MonoBehaviour {

	public MeshFilter MeshFilter;

	public int sizeX;
	public int sizeY;
	public float MaxHeight;
	void Awake () 
	{

		GetComponent<MeshCollider>().sharedMesh = MeshFilter.mesh = CreateMesh (this.sizeX = 10, this.sizeY = 10); //200, 200
		//ApplyHeightMapRandom (MeshFilter.mesh);
	}
	
	void Update () 
	{
	
	}

	Mesh CreateMesh(int widthSegments, int lengthSegments)
	{
		Mesh m = new Mesh();

		int hCount2 = widthSegments+1;
		int vCount2 = lengthSegments+1;
		int numTriangles = widthSegments * lengthSegments * 6;
		int numVertices = hCount2 * vCount2;

		float width = 1;
		float length = 1;
		Vector2 anchorOffset = new Vector2 (0, 0);

		Vector3[] vertices = new Vector3[numVertices];
		Vector2[] uvs = new Vector2[numVertices];
		int[] triangles = new int[numTriangles];
		
		int index = 0;
		float uvFactorX = 1.0f/widthSegments;
		float uvFactorY = 1.0f/lengthSegments;
		float scaleX = 10;
		float scaleY = 10;

		for (float y = 0f; y < vCount2; y++)
		{
			for (float x = 0f; x < hCount2; x++)
			{
				float ran = Random.Range(0f, MaxHeight);
				//float ran = 0;
				vertices[index] = new Vector3(x*scaleX - width/2f - anchorOffset.x,  ran, y*scaleY - length/2f - anchorOffset.y);

				uvs[index++] = new Vector2(x*uvFactorX, y*uvFactorY);
			}
		}

		index = 0;
		for (int y = 0; y < lengthSegments; y++)
		{
			for (int x = 0; x < widthSegments; x++)
			{
				triangles[index]   = (y     * hCount2) + x;
				triangles[index+1] = ((y+1) * hCount2) + x;
				triangles[index+2] = (y     * hCount2) + x + 1;
				
				triangles[index+3] = ((y+1) * hCount2) + x;
				triangles[index+4] = ((y+1) * hCount2) + x + 1;
				triangles[index+5] = (y     * hCount2) + x + 1;
				index += 6;
			}
		}
		
		m.vertices = vertices;
		m.uv = uvs;
		m.triangles = triangles;
		m.RecalculateNormals();

		return m;
	}

	void ApplyHeightMapRandom(Mesh mesh)
	{
		float lastRandom = 0f;

		Vector3[] verts = mesh.vertices;

		for (int i = 0; i < verts.GetLength(0); i++)
		{
			float min 	= Random.Range (-0.5f, 0.5f);
			float max 	= Random.Range (0.5f, 1f);
			lastRandom 	= Random.Range(lastRandom + min, lastRandom + max);
			verts[i].y 	= lastRandom;
		}
		mesh.vertices = verts;
	}

	public Vector3 GetSpawnPoint()
	{
		float raycastHeight 						= 100f;
		float raycastLength 						= 1000f;
		float inFromBoarder 						= 1f;
		Vector3 randomPositionAtRayCastHeight 		= new Vector3 (Random.Range(0f + inFromBoarder, (float)this.sizeX * 10 - inFromBoarder), raycastHeight, Random.Range(0 + inFromBoarder, (float)this.sizeY * 10) - inFromBoarder);
		RaycastHit hit;

		if (Physics.Raycast (randomPositionAtRayCastHeight, Vector3.down, out hit, raycastLength)) 
		{
			if(hit.transform == this.transform)
			{
				return hit.point;
			}

		}
		return this.GetSpawnPoint ();
	}


}

