using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour
{
    /*
        
        
        
    */
    public int selectedcube = -1;
    private int dayoftheweek;
	private int maxCubes = 0;
	private List<GameObject> cubes;
    // Use this for initialization
    private void Start() {
		cubes = new List<GameObject>();
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if(gameObj.name.Contains ("Cube"))
			{
				cubes.Add(gameObj);
				maxCubes++;
			}
		}
    }

    // Update is called once per frame
    private void Update()
    {
        ColorData cols = new ColorData();

        for (int i = 0; i < maxCubes; i++) {
			if(GameObject.Find("Cube" + i))
			{
				GameObject o = GameObject.Find("Cube" + i);
				o.GetComponent<Renderer>().material.color = cols.GetAColorToUse(i);
			}
		}

        if (Input.GetButtonDown("Jump"))
            set_scale_of_cubes();

    }

    private void set_scale_of_cubes()
    {
        GameObject o;
		print (selectedcube);
		print (maxCubes);
		if (selectedcube > -1)
		{
			o = cubes[selectedcube];
			o.transform.localScale = new Vector3(1, 1, 1);
		}
		if (selectedcube >= maxCubes - 1) {
			selectedcube = 0;
		} else {
			selectedcube++;
		}
		o = cubes[selectedcube];
		o.transform.localScale = new Vector3(1, 2, 1);
		
		/*
		if (selectedcube > -1)
        {
            o = GameObject.Find("Cube" + selectedcube);
            o.transform.localScale = new Vector3(1, 1, 1);
        }
		if (selectedcube >= maxCubes) {
			selectedcube = 0;
		} else {
			selectedcube++;
		}
		o = GameObject.Find("Cube" + selectedcube);
        o.transform.localScale = new Vector3(1, 2, 1);
      	*/
    }

    public float yOfCube(int cubeNumber)
    {
        GameObject ob = GameObject.Find("Cube" + selectedcube);
        return ob.transform.localScale.y;
    }
}

public class ColorData
{
    public Color GetAColorToUse(int indexOfTheColorToGet) {
        List<Color> color_list = new List<Color>();
        color_list.Add(new Color(1, 0, 0));
        color_list.Add(new Color(.7f, .7f, 0));
        color_list.Add(new Color(0, 1, 0));
        color_list.Add(new Color(0, .3f, 1));
        color_list.Add(new Color(0, 1, 1));
        return color_list[indexOfTheColorToGet];
    }
}

public class CubeData
{
    // When we find a cube, we should put its data in here for tidier access
}
