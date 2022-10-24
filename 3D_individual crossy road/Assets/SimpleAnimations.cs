using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimations : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;

    float t = 0;
    int direct = 1;
    
    void Update(){
        if (t>=1)
        {
            direct = -1;
        }
        if (t <= 0)
        {
            direct = 1;
        }
        t += direct * Time.deltaTime;
        t = Mathf.Clamp01(t);
        
        transform.position = new Vector3(transform.position.x, curve.Evaluate(t), transform.position.z);
    }

}
