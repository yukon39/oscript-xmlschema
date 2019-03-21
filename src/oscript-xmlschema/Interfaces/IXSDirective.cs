namespace OneScript.XMLSchema
{
    public interface IXSDirective
    {
        XMLSchema ResolvedSchema { get; set; }
        string SchemaLocation { get; set; }
    }
}
