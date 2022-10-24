using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;

    int extend;
    private void Update() {
        // transform.position += Vector3.forward * Time.deltaTime * speed;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (this.transform.position.x < -(extend+1) ||this.transform.position.x > extend+1 )
            Destroy(this.gameObject);
    }

    public void Setup(int extend){
        this.extend = extend;
    }
}
