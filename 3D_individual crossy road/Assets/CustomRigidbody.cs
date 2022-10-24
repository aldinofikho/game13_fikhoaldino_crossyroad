using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRigidbody : MonoBehaviour
{
    [SerializeField] Vector3 gravity = new Vector3(0, -9.81f, 0);
    [SerializeField] float mass;

    Vector3 lessVelocity;
    Vector3 lastPosition;
    Vector3 dv;

    private void Start() {
        lastPosition = this.transform.position;
    }

    // velo = (pos sekarang - pos sebelum / deltaTime)
    // pos sekarang = pos sebelum + (velo * deltaTime)
    void FixedUpdate() {
        // this.transform.position += gravity * Time.fixedDeltaTime;
        Move();

        if (transform.position.y <= 0.5f)
            this.transform.position = new Vector3(
                this.transform.position.x,
                0.5f,
                this.transform.position.z
            );
        
        // Simpan nilai2 di update ini
        lessVelocity = (this.transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = this.transform.position;
        dv = Vector3.zero;
    }

    public void AddForce(Vector3 force, ForceMode forceMode){
        switch (forceMode)
        {
            case ForceMode.Force:
                dv += force * Time.fixedDeltaTime / mass;
                break;
            case ForceMode.Acceleration:
                dv += force * Time.fixedDeltaTime;
                break;
            case ForceMode.Impulse:
                dv += force / mass;
                break;
            case ForceMode.VelocityChange:
                dv += force;
                break;
        }
    }

    public void Move(){
        // Mendapat perubahan velocity
        dv += gravity * Time.fixedDeltaTime;

        // Mendapat velocity sekarang
        var velocity = lessVelocity + dv;

        // Hitung perubahan posisi
        var ds = velocity * Time.fixedDeltaTime;

        // Translate posisi sesuai dengan velocity
        this.transform.position = this.transform.position + ds;

    }
}
