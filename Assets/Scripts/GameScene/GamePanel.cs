using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Text t_Score;//分数
    public Text t_BestScore;//最高分数
    public Button b_Last;//上一步按钮
    public Button b_Restart;//重新开始
    public Button b_Exit;//退出

    public Transform gridParent;

    private int row;//行
    private int col;//列
    public GameObject gridPrefab;//格子预制体
    public MyGrid[][] grids = null;//s所有的格子

    public List<MyGrid> canCreateNumberGrid = new List<MyGrid>();//可以创建数字的格子
    public GameObject numberPrefab;//格子预制体

    private void Awake()
    {
        InitGrid();
    }

    private void Start()
    {
        b_Last.onClick.AddListener(OnLast);
        b_Restart.onClick.AddListener(OnRestart);
        b_Exit.onClick.AddListener(OnExit);
    }

    public void OnLast()
    {

    }

    public void OnRestart()
    {

    }
    public void OnExit()
    {

    }


    //4 200   -20
    //初始化格子
    public void InitGrid()
    {

        

        //获取格子火数量
        int gridNum = PlayerPrefs.GetInt(Const.GameMode, 4);
        //创建格子
        GridLayoutGroup gridLayoutGroup= gridParent.GetComponent<GridLayoutGroup>();

        gridLayoutGroup.constraintCount = gridNum;
        gridLayoutGroup.cellSize = new Vector2(200, 200);

        //创建格子
        row = gridNum;
        col = gridNum;
        //初始化所有格子
        grids = new MyGrid[gridNum][];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //创建i j格子
                if (grids[i]==null)
                {
                    grids[i] = new MyGrid[gridNum];

                }
                grids[i][j]= CreateGrid();
            }
        }

    }


    public MyGrid CreateGrid()
    {
       GameObject grid= GameObject.Instantiate(gridPrefab, gridParent) as GameObject;

        return grid.GetComponent<MyGrid>();
    }

    public void CreateNum()
    {
        //找到这个数字
        canCreateNumberGrid.Clear();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (!grids[i][j].IsHaveNumber())//判断这个格子有没有数字
                {
                    //没有数字
                    canCreateNumberGrid.Add(grids[i][j]);
                }
            }
        }
        if (canCreateNumberGrid.Count==0)
        {
            return;
        }
        //随机一个格子
        int index = Random.Range(0,canCreateNumberGrid.Count);
        //创建数字，把数字放进去


    }

}
