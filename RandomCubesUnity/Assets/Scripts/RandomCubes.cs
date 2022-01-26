/****
 * Created by: Coleton Wheeler
 * Date Create: Jan 24, 2022
 * 
 * Last Edited by: N/A
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawns multiple cubes prefabs into scene
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab; //new gameobject
    [SerializeField] private int numberOfCubes = 0;
    [SerializeField] private float scalingFactor = 0.95f;
    private List<GameObject> gameObjectList; //cube list

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        numberOfCubes++;
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //instatiate the cube

        gObj.name = "Cube" + numberOfCubes; //name property of the object
        gObj.transform.position = Random.insideUnitSphere; //random point inside a sphere around radius of 1

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randomColor;

        gameObjectList.Add(gObj); //add cube to list

        List<GameObject> removeList = new List<GameObject>(); //remove list for game objects
        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //update scale by factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if (scale <= 0.1f) //detects if cube is too small
            {
                removeList.Add(goTemp);
            }
        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp);
        }
    }
}
