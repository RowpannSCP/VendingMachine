using Exiled.API.Interfaces;

namespace VendingMachine
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}