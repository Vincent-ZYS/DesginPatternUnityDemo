using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TemplateMethodPattern04:MonoBehaviour
{
    private void Start()
    {
        IPeople PP1 = new NorthPeople();
        PP1.Eat();
    }
}

public abstract class IPeople
{
    public void Eat()
    {
        OrderFood();
        EatSomething();
        PayBill();
    }

    private void OrderFood()
    {
        Debug.Log("Ready to order foods!");
    }

    public virtual void EatSomething()
    {
    }

    private void PayBill()
    {
        Debug.Log("I am gonna pay my bill!");
    }
}

public class NorthPeople:IPeople
{
    public override void EatSomething()
    {
        base.EatSomething();
        Debug.Log("Gonna Eat Noodle!");
    }
}

public class SouthPeople : IPeople
{
    public override void EatSomething()
    {
        base.EatSomething();
        Debug.Log("Gonna Eat Rice!");
    }
}
