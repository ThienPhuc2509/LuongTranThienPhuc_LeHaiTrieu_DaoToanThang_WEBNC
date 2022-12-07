using DOAN_THWEB_NC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DOAN_THWEB_NC.DesignPattern.ProxyPattern
{
    public class SanPhamProxyPattern : SanPham
    {

        Product product;
        SanPham sanPham;
        int id;


        public SanPhamProxyPattern()
        {
            sanPham = null;
        }

        public SanPhamProxyPattern(Product product)
        {
            this.product = product;
        }

        public SanPhamProxyPattern(int id)
        {
            this.id = id;
        }

        public override void AddSanPham()
        {
            if(sanPham == null)
            {
                sanPham = new concreteSanPham(product);
            }
            sanPham.AddSanPham();
        }

        public override void EditSanPham()
        {
            if (sanPham == null)
            {
                sanPham = new concreteSanPham(product);
            }
            sanPham.EditSanPham();
        }

        public override void RemoveSanPham()
        {
            if (sanPham == null)
            {
                sanPham = new concreteSanPham(id);
            }
            sanPham.RemoveSanPham();
        }
    }
}