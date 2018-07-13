using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinetreeController : MonoBehaviour {

	public Sprite normal;
	public Sprite marked;

	private bool isMarked = false;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		spriteRenderer.sprite = normal;
	}

	public void Mark(){
		spriteRenderer.sprite = marked;
	}

	public void Unmark(){
		spriteRenderer.sprite = normal;
	}

	public void ToggleMarking(){
		isMarked = !isMarked;

		if (isMarked)
			Mark ();
		else
			Unmark ();
	}
}
