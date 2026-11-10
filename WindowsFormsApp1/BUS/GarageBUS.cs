using System.Data;
using System.Collections.Generic;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BUS
{
    public class GarageBUS
    {
        private GarageDAL dal = new GarageDAL();

        public DataTable TimXe(string bienSo)
        {
            return dal.TimXeTheoBienSo(bienSo);
        }

        public bool TiepNhan(KhachHangDTO kh, XeDTO xe)
        {
            return dal.TiepNhanXe(kh, xe);
        }

        public bool LapPhieu(string bienSo, string noiDung, List<ChiTietSuaChuaDTO> dsChiTiet, out string error)
        {
            return dal.LapPhieuSuaChua(bienSo, noiDung, dsChiTiet, out error);
        }
    }
}