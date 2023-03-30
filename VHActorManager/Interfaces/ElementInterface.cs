namespace VHActorManager.Interfaces
{
    internal interface IElementInterface
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    internal interface IColorElementInterface: IElementInterface
    {
        string Hex { get; set; }
    }
}
