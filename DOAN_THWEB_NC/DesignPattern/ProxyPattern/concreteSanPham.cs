using DOAN_THWEB_NC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DOAN_THWEB_NC.DesignPattern.ProxyPattern
{
    public class concreteSanPham : SanPham
    {
        Product product;
        int id;

        private DB_Shop2Entities3 db = new DB_Shop2Entities3();

        public concreteSanPham(Product product)
        {
            this.product = product;
        }

        public concreteSanPham(int id)
        {
            this.id = id;
        }

        public override void AddSanPham()
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public override void EditSanPham()
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public override void RemoveSanPham()
        {
            Product sp = db.Products.Find(id);
            db.Products.Remove(sp);
            db.SaveChanges();
        }
    }
}