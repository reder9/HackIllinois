using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;


[ExecuteInEditMode]
public class ColorGradingProperties : ObjectProperties {
	private Tonemapping toneMapping;
	//public Light _moon;
	public Gradient exposure;
	//public Gradient exposure, brightness,contrast,saturation;
	public Vector2 exposure2 = new Vector2(1, 2), brightness2 = new Vector2(1, 1), contrast2 = new Vector2(1, 1.1f), saturation2 = new Vector2(0, 1);
	public float crossFade;


	
	


	public void Update() {}

	//public new void OnEnable() {
	//	if(debugLogness)Debug.Log("ColorGrading OnEnable");
	//	UpdateTone(time);
	//	base.OnEnable();
	//}

	
}