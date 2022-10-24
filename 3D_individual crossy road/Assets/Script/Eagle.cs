using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField] float speed = 1;
    
    Player player;

    void Update()
    {
        if (this.transform.position.z <= player.CurrentLevel -20)
            return;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (this.transform.position.z <= player.CurrentLevel && player.gameObject.activeInHierarchy == true)
        {
            // player.gameObject.SetActive(false);
            player.transform.SetParent(this.transform);
        }
    }

    public void SetupTarget(Player target){
        this.player = target;
    }
}
