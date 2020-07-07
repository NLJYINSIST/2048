using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    public Number number;//数字
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsHaveNumber()//是否有敌人
    {
        return number!=null;
    }

    public Number GetNumber()
    {
        return number;
    }
    public void SetNumber(Number number)
    {
        this.number = number;
    }


}
