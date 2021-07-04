using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePattern02 : MonoBehaviour
{
    private void Start()
    {
        //Sphere sp1 = new Sphere("YellowSphere");
        //sp1.Draw();
        Cube cb1 = new Cube("RedCube", new DirectX());
        cb1.Draw();
    }
}

public class IShape
{
    public string objectName;
    public IRenderEngine renderEngine;
    public IShape(IRenderEngine renderEngine)
    {
        this.renderEngine = renderEngine;
    }

    public void Draw()
    {
        renderEngine.Render(objectName);
    }
}

public abstract class IRenderEngine
{
    public abstract void Render(string objectName);
}
public class Cube:IShape
{
    public Cube(string objectName, IRenderEngine renderEngine) :base(renderEngine)
    {
        this.objectName = objectName;
    }
}

public class Sphere
{
    public string sphereName;
    public OpenGL gl = new OpenGL();

    public Sphere(string objectName)
    {
        sphereName = objectName;
    }

    public void Draw()
    {
        gl.Render(sphereName);
    }
}

public class DirectX:IRenderEngine
{
    public override void Render(string objectName)
    {
        Debug.Log("The DirectX drawing: " + objectName);
    }
}

public class OpenGL
{
    public void Render(string objectName)
    {
        Debug.Log("The OpenGL drawing: " + objectName);
    }
}
