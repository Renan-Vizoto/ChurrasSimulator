using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grill : MonoBehaviour
{
    [SerializeField] private List<GrillPoints> grillPoints = new List<GrillPoints>();

    public bool PutToCook(CookingObject cookingObject)
    {
        var grillPoint = grillPoints.FirstOrDefault(c => !c.isOccupied);

        if (grillPoint == null) return false;
        
        grillPoint.SetCookingObject(cookingObject);
        cookingObject.Initialize();

        return true;
    }

    public void RemoveCook(CookingObject cookingObject)
    {
        
    }
}

[Serializable]
public class GrillPoints
{
    public Transform transform;
    public CookingObject cookingObject;
    
    public bool isOccupied => cookingObject != null;

    public void SetCookingObject(CookingObject objectToCook)
    {
        objectToCook.transform.SetParent(transform, false);

        cookingObject = objectToCook;
    }

    public void RemoveCookingObject()
    {
        cookingObject = null;
    }
}
