using System;

namespace WebApplication1.Cluster
{
    public class QueryParamter
    {
        const int _maxSize = 100;
        private int _size = 50;


        public int page { get; set; }

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = Math.Min(_maxSize,value);
            }
        }
        public string SortBy { get; set; } = "ID";
        public string Name { get; set; }
    }
}
