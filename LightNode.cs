namespace Lab3.Task5.Composite;

public abstract class LightNode
{
    public abstract string OuterHtml();

    public abstract string InnerHtml();

    public abstract void Accept(ILightNodeVisitor visitor);
}