using System.Xml;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.Test
{
  internal class NitraDeclaration : NitraCompositeElement, IDeclaration
  {
    private readonly IPsiSourceFile _sourceFile;
    public NitraDeclaredElement NitraDeclaredElement { get; private set; }
    public string DeclaredName { get; private set; }
    public NitraTokenElement NameIdentifier { get; private set; }

    public NitraDeclaration(NitraDeclaredElement nitraDeclaredElement, IPsiSourceFile sourceFile, string text, int start, int len)
    {
      _sourceFile = sourceFile;
      var name = text.Substring(start, len);
      DeclaredName = name;
      NameIdentifier = new NitraIdentifier(sourceFile, name, start, len);
      NitraDeclaredElement = nitraDeclaredElement;
    }

    public override NodeType NodeType
    {
      get { return NitraDeclarationType.Instance; }
    }

    public XmlNode GetXMLDoc(bool inherit)
    {
      return null;
    }

    public void SetName(string name)
    {
      throw new System.NotImplementedException();
    }

    public TreeTextRange GetNameRange()
    {
      var id = NameIdentifier;
      TreeOffset startOffset = id.GetTreeStartOffset();
      return new TreeTextRange(startOffset, startOffset + id.GetTextLength());
    }

    public bool IsSynthetic()
    {
      return false;
    }

    public IDeclaredElement DeclaredElement { get { return NitraDeclaredElement;  } }
  }
}