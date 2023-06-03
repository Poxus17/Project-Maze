using UnityEngine;
using System.Collections;

// Tile each material according to the object's scale.
// Author: Lucas A. Mello

[ExecuteInEditMode]
public class TileTexture : MonoBehaviour
{
	void Start()
	{
		// Get scales
		float x = transform.localScale.x;
		float y = transform.localScale.y;
		float z = transform.localScale.z;
		float max = x > y ? x : y;
		max = max > z ? max : z;
		
		// Get the mesh
	    Mesh theMesh;
	    theMesh = this.transform.GetComponent<MeshFilter>().mesh as Mesh;
	
	    // Now store a local reference for the UVs
	    Vector2[] theUVs = new Vector2[theMesh.uv.Length];
	    theUVs = theMesh.uv;
		
		// Vertices order:
		//    2    3    0    1   z+
		//    6    7   10   11   z-
		//   19   17   16   18   x-
		//   23   21   20   22   x+
		//    4    5    8    9   Top
		//   15   13   12   14   Bottom
	
	    // set UV co-ordinates
		theUVs[2] = new Vector2(0f, y/max);
	    theUVs[3] = new Vector2(x/max, y/max);
	    theUVs[0] = new Vector2(0f, 0f);
	    theUVs[1] = new Vector2(x/max, 0f);
		
		theUVs[11] = new Vector2(0f, y/max);
	    theUVs[10] = new Vector2(x/max, y/max);
	    theUVs[7] = new Vector2(0f, 0f);
	    theUVs[6] = new Vector2(x/max, 0f);
		
		theUVs[19] = new Vector2(0f, y/max);
	    theUVs[17] = new Vector2(z/max, y/max);
	    theUVs[16] = new Vector2(0f, 0f);
	    theUVs[18] = new Vector2(z/max, 0f);
		
	    theUVs[23] = new Vector2(0f, y/max);
	    theUVs[21] = new Vector2(z/max, y/max);
	    theUVs[20] = new Vector2(0f, 0f);
	    theUVs[22] = new Vector2(z/max, 0f);
		
		theUVs[4] = new Vector2(0f, z/max);
	    theUVs[5] = new Vector2(x/max, z/max);
	    theUVs[8] = new Vector2(0f, 0f);
		theUVs[9] = new Vector2(x/max, 0f);
		
	    theUVs[15] = new Vector2(0f, 0f);
	    theUVs[13] = new Vector2(0f, 0f);
	    theUVs[12] = new Vector2(0f, 0f);
		theUVs[14] = new Vector2(0f, 0f);		
	
	    // Assign the mesh its new UVs
	    theMesh.uv = theUVs;
		
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(max/2f, max/2f));
	}
}
