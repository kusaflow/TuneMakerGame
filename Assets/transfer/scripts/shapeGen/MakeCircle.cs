using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCircle : MonoBehaviour
{
    public GameObject brickPrefab; // Prefab of the brick

    public float brickSize = 1.0f; // Size of each brick

    public int brickCount = 100; // Number of bricks in the circle
    public float radius = 5.0f; // Radius of the circle

    public List<Vector2> NeglectParts;

    public float extroRotaionAfterSpawn = 0.0f;

    void OnEnable()
    {
        GenerateCircle(); // Example: Generate a circle at the origin
        transform.transform.Rotate(0, 0, extroRotaionAfterSpawn);
    }

    public void GenerateCircle()
    {
        Vector3 center = transform.position;

        for (int i = 0; i < brickCount; i++)
        {

            float angle = i * Mathf.PI * 2 / brickCount;
            //Debug.Log("Angle: " + angle);
            //checkList if in between angle then continue
            bool shouldContinue = false;

            foreach (Vector2 v in NeglectParts)
            {
                //change the angle to deg from radian
                float angleinDeg = angle * Mathf.Rad2Deg;
                if (angleinDeg >= v.x && angleinDeg <= v.y)
                {
                    shouldContinue = true;
                    break;
                }
            }

            if (shouldContinue)
                continue;

            Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius + center;

            brickPrefab = GetComponent<BrickProvider>().provideBlockToDraw();
            GameObject brick = Instantiate(brickPrefab, position, Quaternion.identity, transform);

            // Rotate the brick to face the center
            brick.transform.LookAt(center);


            Vector3 rotation = brick.transform.rotation.eulerAngles;
            rotation.z = rotation.x;
            rotation.y = rotation.x = 0;

            if (transform.position.x <= position.x)
                brick.transform.rotation = Quaternion.Euler(rotation);
            else
            {
                //scale the brick to face the center
                //brick.transform.localScale = new Vector3(1, 1, 1);
                rotation.z = rotation.z * -1;
                brick.transform.rotation = Quaternion.Euler(rotation);
            }

        }
    }


}
