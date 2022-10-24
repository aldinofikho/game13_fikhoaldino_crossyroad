using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text stepText;
    [SerializeField] ParticleSystem particleDie;
    [SerializeField, Range(0.01f, 1f)] float moveDuration = 0.2f;
    [SerializeField, Range(0.01f, 1f)] float jumpHigh = 0.5f;

    private float backBoundary;
    private float leftBoundary;
    private float rigthBoundary;

    [SerializeField ] private int maxTravel;
    public int MaxTravel {get => maxTravel;}
    [SerializeField] private int currentLevel;
    public int CurrentLevel {get => currentLevel;}

    public bool isDie {get => this.enabled == false;}

    public void Setup(int minZpos, int extend){
        backBoundary = minZpos - 1;
        leftBoundary = -(extend + 1);
        rigthBoundary = extend + 1;
    }

    private void Update()
    {

        var Movedirec = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            Movedirec += new Vector3(0,0,1);
    
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            Movedirec += new Vector3(0,0,-1);

        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
            Movedirec += new Vector3(1,0,0);
    
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            Movedirec += new Vector3(-1,0,0);
        
        if (Movedirec == Vector3.zero)
            return;
        
        if (IsJump() == false)
            Jump(Movedirec);

    }

    private void Jump(Vector3 targetDirection){

        // var targetPosition = transform.position + new Vector3(
        //     x: direc.x,
        //     y: 0,
        //     z: direc.y);

        // Atur posisi
        var targetPosition = transform.position + targetDirection;

        transform.LookAt(targetPosition);
        
        var moveSeq = DOTween.Sequence(transform);
        moveSeq.Append(transform.DOMoveY(jumpHigh, moveDuration/2));
        moveSeq.Append(transform.DOMoveY(0, moveDuration/2));
        // transform.DOMoveY(0.5f, 0.1f).OnComplete(()=> transform.DOMoveY(0, 0.1f));

        if (Tree.AllPositions.Contains(targetPosition))
            return;

        if (targetPosition.z <= backBoundary || 
            targetPosition.x < leftBoundary || 
            targetPosition.x > rigthBoundary)
            return;

        // Gerakan maju mundur samping kanan kiri
        transform.DOMoveX(targetPosition.x, moveDuration );
        transform
            .DOMoveZ(targetPosition.z, moveDuration)
            .OnComplete(UpdateTravel);
    }

    private void UpdateTravel (){
        currentLevel = (int) this.transform.position.z;

        if (currentLevel > maxTravel)
            maxTravel = currentLevel;

        stepText.text = "Step : " + maxTravel.ToString();
    }

    public bool IsJump(){
        return DOTween.IsTweening(transform);
    }

    private void OnTriggerEnter(Collider other) {
        // eksekusi satu kali ketika objek bersentuhan
        // var car  = other.GetComponent<Car>();

        // if (car != null)
        // {
        //     AnimateDie(car);
        // }

        if (this.enabled == false)
        {
            return;
        }

        if (other.tag == "Car")
        {
            AnimateCrash();
        }
    }

    private void AnimateCrash()
    {
        // var isRight = car.transform.rotation.y == -90;

        // transform.DOMoveX(isRight ? 8 : -8, 2);
        // transform.DORotate(Vector3.forward*360, 2)
        // .SetLoops(1, LoopType.Restart);

            // Objek Hewan gepeng
        transform.DOScaleY(0.05f, 0.2f);
        transform.DOScaleX(1.5f, 0.2f);
        transform.DOScaleZ(1.5f, 0.2f);

            // Mengehntikan fungsi script atau pada input key
        this.enabled = false;
        particleDie.Play();
    }

    private void OnTriggerExit(Collider other) {
        // Ekesekusi setiap frame selama objek masih bersentuhan
    }

    private void OnTriggerStay(Collider other) {
        // eksekusi satu kali pada frame ketika objek tidak bersentuhan
    }


}
