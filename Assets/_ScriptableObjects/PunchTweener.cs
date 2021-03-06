﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class AbstractTweener : ScriptableObject {
	public abstract void Tween(Transform transform);
}

[CreateAssetMenu]
public class PunchTweener : AbstractTweener {
	public float punchScale;
	public float duration;
	public int vibrato;
	public float elastacity;

	public override void Tween(Transform transform) {
		var scl = new Vector3(punchScale, punchScale, punchScale);
		transform.DOPunchScale(scl, duration, vibrato, elastacity);
	}

}
