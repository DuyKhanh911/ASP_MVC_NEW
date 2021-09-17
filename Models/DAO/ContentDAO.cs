using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ContentDAO
    {
        OnlineShopDBContext mydb = new OnlineShopDBContext();

        public Content GetByID(long id) {
            return mydb.Contents.Find(id);
        }
    }
}
