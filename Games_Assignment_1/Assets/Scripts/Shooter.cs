using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public GameObject[] shooters = new GameObject[2];

    public GameObject bullets;
    public RawImage targetSign;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Transform target = shooters[i].transform.GetChild(0);
                RectTransform targetT = targetSign.GetComponent<RectTransform>();
                Vector3 targetPos = targetT.position - shooters[i].transform.position;
                Quaternion targetRot = Quaternion.LookRotation(targetPos,Vector3.up);
                GameObject bulletFired = Instantiate(bullets, target.transform.position, targetRot);
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                
                yield return  new WaitForSeconds(1);
                
            }

            yield return null;
        }
    }
}
