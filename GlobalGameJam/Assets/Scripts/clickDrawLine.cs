using UnityEngine;
using System.Collections;

public class clickDrawLine : MonoBehaviour {

	public bool drawingLine = false;
	private Vector3 curScreenPoint;
	private Vector3 screenPoint;
	private Vector3 mousePos;
	private LineRenderer line;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (drawingLine) {
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (curScreenPoint);
			line.SetPosition (1, mousePos);

			if (Input.GetMouseButtonDown(0)) {
				drawingLine = false;
			}
		}
	}

	void OnMouseDown()
	{
		if(!drawingLine)
		{
			drawingLine = true;
			line = (LineRenderer)gameObject.AddComponent(typeof(LineRenderer));
			line.SetVertexCount(2);
			line.SetWidth (0.5f, 0.5f);
			line.SetColors (Color.white,Color.red);

			line.SetPosition(0,gameObject.transform.position);
			//curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			//mousePos = Camera.main.ScreenToWorldPoint (curScreenPoint);
			//line.SetPosition(1,mousePos);
				
		}

	}

}

