using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Collections
{
    public class GenericComparer<T> : IComparer<T>
    {
        private string sort_property;

        public string SortProperty
        {
            get { return sort_property; }
            set { sort_property = value; }
        }

        public int Compare(T object1, T object2)
        {
            int result = 0;
            Type type1 = object1.GetType();
            Type type2 = object2.GetType();

            try
            {
                Object[] args = null;
                Type value_type = type1.GetProperty(sort_property).GetValue(object1, args).GetType();

                String valor1 = type1.GetProperty(sort_property).GetValue(object1, args).ToString();
                String valor2 = type2.GetProperty(sort_property).GetValue(object2, args).ToString();

                if (value_type == typeof(String))
                {
                    result = valor1.CompareTo(valor2);
                }
                else if (value_type == typeof(int))
                {
                    result = Convert.ToInt32(valor1) - Convert.ToInt32(valor2);
                }
                else if (value_type == typeof(float))
                {
                    result = (int)(Convert.ToSingle(valor1) - Convert.ToSingle(valor2));
                }
                else if (value_type == typeof(DateTime))
                {
                    result = (int)(Convert.ToDateTime(valor1).Ticks - Convert.ToDateTime(valor2).Ticks);
                }

            }
            catch (Exception)
            {
                result = 0;
                //throw;
            }

            return result;
        }
    }
}
