using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {
        OnlineShopDBContext mydb = new OnlineShopDBContext();

        public List<Category> listall() {
            return mydb.Categories.Where(c => c.Status == true).ToList();
        }
    }
}
