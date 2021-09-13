using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numCubes = 8;
    public float cubeBottomZ = 0f;
    public float cubeSpacingZ = 2f;
    public float cubeBottomX = 0f;
    public float cubeSpacingX = 2f;
    public List<GameObject> cubeList;
    

    // Start is called before the first frame update
    void Start()
    {
        cubeList = new List<GameObject>();
        for (int i = 0; i < numCubes; i++)
        {
            GameObject tCubeGo = Instantiate<GameObject>(cubePrefab);
            Vector3 pos = Vector3.zero;
            pos.z = cubeBottomZ + (cubeSpacingZ * i);
            tCubeGo.transform.position = pos;
            cubeList.Add(tCubeGo);

            Vector3 posX = Vector3.zero;
            posX.z = cubeBottomZ + (cubeSpacingZ * (i));
            for (int x = 0; x < 7; x++)
            {
                GameObject tCubeGoX = Instantiate<GameObject>(cubePrefab);
                posX.x = cubeBottomX + (cubeSpacingX * (x + 1));
                tCubeGoX.transform.position = posX;
                cubeList.Add(tCubeGoX);
            }
        }
    }
}
