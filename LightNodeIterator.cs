using System.Collections.Generic;

namespace Lab3.Task5.Composite;

public static class LightNodeIterator
{
    public static IEnumerable<LightNode> DepthFirst(LightNode root)
    {
        if (root is LightElementNode element)
        {
            foreach (var node in element.TraverseDepthFirst())
            {
                yield return node;
            }
        }
        else
        {
            yield return root;
        }
    }

    public static IEnumerable<LightNode> BreadthFirst(LightNode root)
    {
        if (root is LightElementNode element)
        {
            foreach (var node in element.TraverseBreadthFirst())
            {
                yield return node;
            }
        }
        else
        {
            yield return root;
        }
    }
}
