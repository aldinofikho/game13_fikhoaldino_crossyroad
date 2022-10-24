using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBlock : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject repeat;

    private int extend;

    public int Extend {get => extend; }
    
    public void Build(int extend){
        this.extend = extend;

        // Blok batas kiri kanan
        for (int i = -1; i <= 1; i++)
        {
            if(i==0)
                continue;

            var m = Instantiate(main);
            m.transform.SetParent(this.transform);
            m.transform.localPosition = new Vector3((extend+1)*i,0,0);
            m.transform.GetComponentInChildren<Renderer>().material.color *= Color.grey;
        }

        // Buat blok utama
        main.transform.localScale = new Vector3(
            x: extend*2+1,
            y: main.transform.localScale.y,
            z: main.transform.localScale.z
        );

        // Buat repeat jika ada
        if (repeat == null)
        {
            return;
        }

        for (int x = -(extend+1); x <= extend+1; x++)
        {
            if(x==0)
                continue;

            var r = Instantiate(repeat);
            r.transform.SetParent(this.transform);
            r.transform.localPosition = new Vector3(x,0,0);
        }
    }


}
