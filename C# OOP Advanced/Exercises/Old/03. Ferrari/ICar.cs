﻿namespace _03.Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }

        string PushTheGas();

        string Brake();
    }
}