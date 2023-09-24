using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private DataManger dataManger;    

    void Start()
    {
        dataManger = GameObject.Find("DataManager").GetComponent<DataManger>();
    }
    public void ResetToInitiial()
    {
        InitBeginValues.Instance.InitBeginValue();

        dataManger.Save();

        SceneManager.LoadScene(0);
    }


}
