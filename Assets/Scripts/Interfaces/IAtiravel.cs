using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAtiravel
{
    public void SetarTiro(Transform origem, Vector3 target, float bonusDano, float bonusVelocidade);
    public float GetDano();
}
