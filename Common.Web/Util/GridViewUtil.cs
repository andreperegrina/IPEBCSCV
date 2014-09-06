using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web.UI.WebControls;

namespace Common.Web.Util
{
   public class GridViewUtil
    {

        public static GridView EmptyGridFix(GridView gridView, Type t, ObjectDataSource dataSource)
        {

            Type[] array = new Type[0];
            Object[] args = new Object[0];
            Object empty_element = t.GetConstructor(array).Invoke(args);

            IList data_elements = (IList)dataSource.Select();
            
            if (data_elements.Count == 0 && gridView.DataSourceID != "")
            {
                IList templist = new ArrayList();
                templist.Add(empty_element);

                gridView.DataSourceID = null;
                gridView.DataSource = templist;
                gridView.DataBind();

                gridView.Rows[0].Visible = false;
                gridView.Rows[0].Controls.Clear();
            }
            return gridView;
        }
    }
}
