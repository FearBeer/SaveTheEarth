using UnityEngine;
using UnityEngine.Events;

public class MoneyBank : MonoBehaviour
{
    private int allMoney;

    public UnityEvent<int> OnMoneyChange;
    void Start()
    {
        allMoney = DataManger.Instance.money;
    }

    public int GetAllMoneyValue()
    {
        return allMoney;
    }
    
    //Use -value to spend money
    public void ChangeMoneyValue(int value)
    {
        allMoney += value;
        OnMoneyChange.Invoke(allMoney);
        DataManger.Instance.money = allMoney;
    }
}
