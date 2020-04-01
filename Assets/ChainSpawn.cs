using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainSpawn : MonoBehaviour
{


    public GameObject link;
    private Quaternion rotate;
    private float iheight;
    private float height;
    private float currentheight;
    public int linknumber;
    public float rlspeed;
    private GameObject go;
    public GameObject[] goarray;
    private int i;
    private int j;
    private int k;
    // Start is called before the first frame update
    void Start()
    {
        goarray = new GameObject[250];
        i = 0;
        j = linknumber;
        k = linknumber;
        iheight = this.transform.position.y;
        height = iheight;
        for (i=0; i < linknumber; i++)
        {
            height = height - 0.106f;
            rotate = Quaternion.Euler(0, 90 * ((float)i+1f), 90);
            link.name = string.Format("chainLink{0}", j);
            go = Instantiate(link, new Vector3(0f, height, 0f), rotate) as GameObject;
            goarray[j] = go;
            j--;
        }
    }
    void RaiseChain()
    {
        if (currentheight - iheight > 0.106f)
        {
            transform.Translate(0, -0.106f, 0, Space.World);
            transform.Rotate(0, 90, 0, Space.World);
            Destroy(goarray[k]);
            k--;
        }
    }
    void LowerChain()
    {
        if (currentheight - iheight < 0.106f)
        {
            transform.Translate(0, +0.106f, 0, Space.World);
            transform.Rotate(0, 90, 0, Space.World);
            k++;
            rotate = Quaternion.Euler(0, 90 * ((float)k + 1f), 90);
            link.name = string.Format("chainLink{0}", k);
            go = Instantiate(link, new Vector3(goarray[k-1].transform.position.x, iheight+0.106f, goarray[k - 1].transform.position.z), rotate) as GameObject;
            goarray[k] = go;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        currentheight = this.transform.position.y;
        if (Input.GetKey("e"))
        {
            transform.Translate(0, Time.deltaTime * rlspeed, 0, Space.World);
            RaiseChain();
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(0, -1f * Time.deltaTime * rlspeed, 0, Space.World);
            LowerChain();
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Time.deltaTime * rlspeed, 0,0, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate( -1f * Time.deltaTime * rlspeed, 0,0, Space.World);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(0,0,Time.deltaTime * rlspeed,  Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0,0,-1f * Time.deltaTime * rlspeed,  Space.World);
        }
    }
}
