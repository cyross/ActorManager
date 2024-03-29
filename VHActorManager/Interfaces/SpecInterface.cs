﻿namespace VHActorManager.Interfaces
{
    internal interface ISpecInterface
    {
        int Id { get; set; } 
        string Name { get; set; }
    }

    internal interface IColorSpecInterface: ISpecInterface
    {
        string Hex { get; set; }
    }
}
