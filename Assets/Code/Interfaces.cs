using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisualDamageable
{
    IEnumerator VisualFeedBack();
}
public interface IHealeable{
    void AddHealth();
} 
