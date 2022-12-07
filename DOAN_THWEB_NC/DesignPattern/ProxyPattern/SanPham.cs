using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DOAN_THWEB_NC.DesignPattern.ProxyPattern
{
    public abstract class SanPham 
    {
        public abstract void AddSanPham();
        public abstract void RemoveSanPham();
        public abstract void EditSanPham();
    }
}