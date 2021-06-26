using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPattern01 : MonoBehaviour
{
    private void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStatus01(context));
        context.Handle(5);
        context.Handle(20);
        context.Handle(30);
        context.Handle(4);
        context.Handle(3);
    }
}

public class Context
{
    private IState mState;

    public void SetState(IState state)
    {
        mState = state;
    }

    public void Handle(int arg)
    {
        mState.Handle(arg);
    }
}

public interface IState
{
    void Handle(int arg);
}

public class ConcreteStatus01 : IState
{
    private Context mContext;
    public ConcreteStatus01(Context context)
    {
        mContext = context;
    }
    public void Handle(int arg)
    {
        Debug.Log("ConcreteStatus01:" + arg);
        if(arg > 10)
        {
            mContext.SetState(new ConcreteStatus02(mContext));
        }
    }

}

public class ConcreteStatus02 : IState
{
    private Context mContext;

    public ConcreteStatus02(Context context)
    {
        mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStatus02:" + arg);
        if (arg <= 10)
        {
            mContext.SetState(new ConcreteStatus01(mContext));
        }
    }
}