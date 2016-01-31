using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class lineHandler : MonoBehaviour {

	private bool drawingLine;
	public Color lineColor;
	private int numLines;
	private List<Vector3> linePoints;
	private List<LineRenderer> lines;
	private List<GameObject> gameObjects;
	private Mesh damageArea;
	private Vector3 curScreenPoint;
	private Vector3 screenPoint;
	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		linePoints = new List<Vector3>();
		lineColor = new Color(0.8f,0f,0f,0.5f);
		drawingLine = false;
		lines = new List<LineRenderer>();
		gameObjects = new List<GameObject>();
		numLines = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (drawingLine) {
			//Make line tail follow mouse.
			curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);//screenPoint.z);
			mousePos = Camera.main.ScreenToWorldPoint (curScreenPoint);
			Vector3 mouseLinePos = new Vector3 (mousePos.x,mousePos.y,0);
			if (linePoints.Count > 0) {
				linePoints [linePoints.Count - 1] = mouseLinePos;
			}
			//lines[lines.Count-1].SetPosition(0,linePoints[linePoints.Count-2]);
			if (lines.Count > 0) {
				lines [lines.Count - 1].SetPosition (0, linePoints [linePoints.Count - 2]);
				lines [lines.Count - 1].SetPosition (1, linePoints [linePoints.Count - 1]);
			}
		}
		//Handle clicking  towers
		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if(hit.collider != null && hit.collider.gameObject.CompareTag("tower"))
			{
				Vector3 candlePos = hit.collider.gameObject.transform.position;

				if (drawingLine) {
					//Detect if click a candle already in the array.
					if (linePoints.IndexOf(candlePos) != -1) {
						//If found, end the line.
						lines[lines.Count-1].SetPosition (1, candlePos);
						drawingLine = false;
						//Create damage area
						//damageArea = CreateDamageArea();
						CreateDamageArea();
						return;
					}

					//Add lines to existing line
					numLines++;
					lines[lines.Count-1].SetPosition (1, candlePos);
					LineRenderer newLine = CreateLine ();
					newLine.SetPosition (1, candlePos);

					lines.Add (newLine);
					linePoints.Insert(linePoints.Count-1,candlePos);
					newLine.enabled = true;
				}

				if (!drawingLine) {
					//Clear old lines
					linePoints.Clear ();
					Destroy (damageArea);
					for(int i = 0; i < gameObjects.Count; i++)
					{
						
						Destroy(gameObjects[i].gameObject);
						//Destroy (gameObjects [i].gameObject.GetComponent<LineRenderer> ().material);
					}
					//Start drawing new line
					LineRenderer newLine = CreateLine ();
					newLine.SetPosition(0,candlePos);
					newLine.SetPosition (1, candlePos);
					newLine.enabled = true;
				
					linePoints.Add(candlePos);
					linePoints.Add(candlePos);
					//linePoints[1]=candlePos;
					lines.Add (newLine);
					drawingLine = true;
					numLines = 1;
				}
			}

		}
	}

	LineRenderer CreateLine(){
		GameObject newGO = new GameObject();
		gameObjects.Add (newGO);
		LineRenderer newLine = (LineRenderer)newGO.AddComponent (typeof(LineRenderer));
		newLine.SetVertexCount(2);
		newLine.SetColors(lineColor, lineColor);
		float lineWidth = 0.5f;
		newLine.SetWidth (lineWidth,lineWidth);
		newLine.enabled = false;

		Material whiteDiffuseMat = new Material(Shader.Find("Sprites/Default"));
		newLine.material = whiteDiffuseMat;

		return newLine;
	}

	void CreateDamageArea()
	{

		/*Triangulator tri = new Triangulator (linePoints.ToArray());
		int[] triangles = tri.Triangulate ();
		var mesh = new Mesh ();
		GameObject go = new GameObject ();
		gameObjects.Add(go);


		mesh.vertices = linePoints.ToArray();
		mesh.triangles = triangles;
		Debug.Log (mesh);
		 go.AddComponent<MeshFilter>();
		MeshFilter mf = go.GetComponent<MeshFilter> ();
		Debug.Log (mf);
		mf.mesh = mesh;
		//return mesh;*/
		GameObject go = new GameObject ();
		PolygonCollider2D collider = go.AddComponent<PolygonCollider2D> ();
		collider.points = convertArray (linePoints.ToArray ());
		//new PolygonCollider2D();


	}

	private static Vector2[] convertArray(Vector3[] points)
	{
		Vector2[] array = new Vector2[points.Length];
		for(int i = 0; i < points.Length; i++)
		{
			array[i] = new Vector2 (points[i].x, points[i].y);
		}
		return array;

	}

}
