using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyPattern03 : MonoBehaviour
{
    private void Start()
    {
        Context ct = new Context();
        ct.strategy = new ConcreteStrategyA();
        ct.Calculate();
        ct.strategy = new ConcreteStrategyB();
        ct.Calculate();
    }

    public class Context
    {
        public IStrategy strategy;

        public void Calculate()
        {
            strategy.Cal();
        }
    }

    public interface IStrategy
    {
        void Cal();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public void Cal()
        {
            Debug.Log("Using Strategy A to solve this problem!");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void Cal()
        {
            Debug.Log("Using Strategy B to solve this problem!");
        }
    }
}
