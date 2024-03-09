using System;

namespace DexterityApp.Contracts.ViewModels;

interface IWindows
{
    public Action Hide { get; set; }
}