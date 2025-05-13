using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
    public class GoldenLayoutComponent
    {
        private readonly Dictionary<Type, string> _componentMap;

        public GoldenLayoutComponent(Dictionary<Type, string> components)
        {
            _componentMap = components;
        }

        public string? GetIdentifier(Type componentType)
        {
            return _componentMap.TryGetValue(componentType, out var id) ? id : null;
        }

        public Type? GetTypeByIdentifier(string identifier)
        {
            return _componentMap.FirstOrDefault(x => x.Value == identifier).Key;
        }

        public IReadOnlyDictionary<Type, string> GetAll() => _componentMap;
    }

}
