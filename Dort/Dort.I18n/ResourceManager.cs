
using System;
using System.Collections.Generic;
using System.Text;

namespace Dort.I18n
{
    public static class ResourceManager
    {
        private static List<IResourceCollection> _collections;
        
        static ResourceManager()
        {
            _collections = new List<IResourceCollection>();
        }

        public static IResourceCollection GetCollection()
        {

        }
    }
}
