//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//  [SerializeField] GameObject animal;
//[SerializeField] Vector3 offset;
//private void Start() {
//   offset = this.transform.position - animal.transform.position;
//}

//Vector3 lastPos;
//void Update()
//{
//  if (lastPos == animal.transform.position)
//    return;
//var targetAnimalPos = new Vector3(animal.transform.position.x, 0, animal.transform.position.z);

//transform.position = targetAnimalPos + offset;
//lastPos = animal.transform.position;
//}
//}
