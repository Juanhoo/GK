﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlidingBackground : MonoBehaviour
{
	public Renderer rend;

	public void SlideTexture(float speed, Vector3 playerForward) {
		
		rend.material.SetTextureOffset("_MainTex", rend.materials[0].mainTextureOffset + new Vector2(4f * speed, 0) * playerForward);
	}
}