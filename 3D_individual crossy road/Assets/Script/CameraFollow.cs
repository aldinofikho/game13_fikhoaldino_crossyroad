using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Vector3 offset;
    private void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    Vector3 lastPos;
    void Update()
    {
        if (player.isDie || lastPos == player.transform.position)
            return;
        var targetAnimalPos = new Vector3(
            player.transform.position.x,
            0,
            player.transform.position.z
            );

        transform.position = targetAnimalPos + offset;
        lastPos = player.transform.position;
    }
}
