using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] int bulletRotation = 90;
    public Vector3 direction;


    [Header("Scatter Options", order = 0)]
    [Space(-10, order = 1)]
    [Header("CAUTION! DO NOT PUT TOO MANY SCATTERS", order = 2)]
    public Shot scatterShot;
    [Range(0,3)] public int numberOfScatters = 0;
    public int scatterObjects = 0;
    public int scattersFromScatters = 0;
    bool scatter = true;
    bool isScatter;
    Vector2[] scatterDir;

    [Header("Cat options")]
    [SerializeField] bool isCatLauncher;
    [SerializeField] Cat cat;

    void Start()
    {
        if (!isScatter)
        {
            direction = GameObject.Find("Direction").transform.position;
            transform.position = GameObject.Find("Firepoint").transform.position;
        }
        //var rotationTarget = direction;
        Vector3 rotationDirection = direction - transform.position;
        float angle = Mathf.Atan2(rotationDirection.y, rotationDirection.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - bulletRotation);
        //transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Player").transform.eulerAngles.z);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        if (transform.position == new Vector3(direction.x, direction.y))
        {
            if(scatter) { Scatter(); }
            Destroy(gameObject);

        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Ground"))
        {
            if (scatter) { Scatter(); }

            if(isCatLauncher && other.CompareTag("Enemy"))
            {
                Debug.Log("Cat hit");
                Cat catInstance = Instantiate(cat, other.transform.position, transform.rotation);
                catInstance.transform.parent = other.gameObject.transform;
            }

            Destroy(gameObject);
        }
    }

    private void Scatter()
    {
        if(numberOfScatters > 0)
        {
            scatter = false;

            scatterDir = new Vector2[32];

            for (int i = 0; i < scatterObjects; i++)
            {
                scatterDir = new Vector2[32];

                GetScatterDirection();

                Shot scatter = Instantiate(scatterShot, new Vector3(transform.position.x + scatterDir[i].x, transform.position.y + scatterDir[i].y, transform.position.z), transform.rotation);
                scatter.direction = new Vector2(transform.position.x + scatterDir[i].x * 5, transform.position.y + scatterDir[i].y * 5);
                scatter.isScatter = true;
                scatter.scatterObjects = scattersFromScatters;
                if(numberOfScatters <= 3)
                {
                    scatter.numberOfScatters = numberOfScatters - 1;
                } else
                {
                    scatter.numberOfScatters = 2;
                }
                scatter.scatter = true;
            }
            
        }
    }

    private void GetScatterDirection()
    {
        scatterDir[0] = new Vector2(1, 0);
        scatterDir[1] = new Vector2(0, 1);
        scatterDir[2] = new Vector2(-1, 0);
        scatterDir[3] = new Vector2(0, -1);
        scatterDir[4] = new Vector2(1, 1);
        scatterDir[5] = new Vector2(-1, -1);
        scatterDir[6] = new Vector2(1, -1);
        scatterDir[7] = new Vector2(-1, 1);
        scatterDir[8] = new Vector2(1, 0.5f);
        scatterDir[9] = new Vector2(-1, -0.5f);
        scatterDir[10] = new Vector2(0.5f, -1);
        scatterDir[11] = new Vector2(-0.5f, 1);
        scatterDir[12] = new Vector2(0.5f, 0.5f);
        scatterDir[13] = new Vector2(-0.5f, -0.5f);
        scatterDir[14] = new Vector2(0.5f, -0.5f);
        scatterDir[15] = new Vector2(-0.5f, 0.5f);
        scatterDir[16] = new Vector2(0.25f, 0.25f);
        scatterDir[17] = new Vector2(-0.25f, -0.25f);
        scatterDir[18] = new Vector2(0.25f, -0.25f);
        scatterDir[19] = new Vector2(-0.25f, 0.25f);
        scatterDir[20] = new Vector2(0.5f, 0.25f);
        scatterDir[21] = new Vector2(-0.5f, -0.25f);
        scatterDir[22] = new Vector2(0.5f, -0.25f);
        scatterDir[23] = new Vector2(-0.5f, 0.25f);
        scatterDir[24] = new Vector2(0.25f, 0.5f);
        scatterDir[25] = new Vector2(-0.25f, -0.5f);
        scatterDir[26] = new Vector2(0.25f, -0.5f);
        scatterDir[27] = new Vector2(-0.25f, 0.5f);
        scatterDir[28] = new Vector2(0.125f, 0.125f);
        scatterDir[29] = new Vector2(-0.125f, -0.125f);
        scatterDir[30] = new Vector2(0.125f, -0.125f);
        scatterDir[31] = new Vector2(-0.125f, 0.125f);

    }
}