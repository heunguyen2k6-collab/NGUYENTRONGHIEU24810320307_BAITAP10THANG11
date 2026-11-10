using System.Collections.Generic;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BUS
{
    public class KaraokeBUS
    {
        private KaraokeDAL dal = new KaraokeDAL();

        public List<PhongHatDTO> LayDanhSachPhong()
        {
            return dal.LayDanhSachPhong();
        }

        public bool MoPhong(int maPhong)
        {
            return dal.MoPhong(maPhong);
        }

        public int LayMaHD(int maPhong)
        {
            return dal.LayMaHDChuaThanhToan(maPhong);
        }

        public bool GoiDichVu(int maHD, int maDV, int soLuong, decimal donGia)
        {
            return dal.GoiDichVu(maHD, maDV, soLuong, donGia);
        }

        public bool ThanhToan(int maHD, int maPhong, out string err)
        {
            return dal.ThanhToan(maHD, maPhong, out err);
        }
    }
}