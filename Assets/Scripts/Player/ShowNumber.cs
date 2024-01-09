using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNumber : MonoBehaviour
{
    public Image crossHairs;
    
    public static RaycastHit hitObject;
    public static Ray ray;

    private EnemyScript enemyCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        
         ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));


        if (Physics.Raycast(ray, out hitObject, Mathf.Infinity)
            && hitObject.transform.CompareTag("Enemy"))
        {
            enemyCode = hitObject.transform.GetComponent<EnemyScript>();
            enemyCode.displayEnemyNumber = true;
        }
    }
}
