namespace Lab3.Task5.Composite;

public interface ILightNodeVisitor
{
    void VisitElement(LightElementNode element);

    void VisitText(LightTextNode text);
}
