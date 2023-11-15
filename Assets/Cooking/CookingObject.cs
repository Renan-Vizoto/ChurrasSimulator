using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingObject : MonoBehaviour
{
    [SerializeField] private float timeToCook;

    [SerializeField] private GameObject raw;
    [SerializeField] private GameObject cooked;

    private float _cookingPercentage;

    private Coroutine cookingCoroutine;
    
    [ContextMenu("Start")]
    public void Initialize()
    {
        cookingCoroutine = StartCoroutine(StartCooking());
    }

    private IEnumerator StartCooking()
    {
        while (_cookingPercentage < 100)
        {
            yield return new WaitForSeconds(1);
            _cookingPercentage += 100 / timeToCook;
        }
        
        raw.SetActive(false);
        cooked.SetActive(true);
    }

    [ContextMenu("Stop")]
    public void StopCooking()
    {
        if (cookingCoroutine != null)
        {
            StopCoroutine(cookingCoroutine);
        }
    }
}
