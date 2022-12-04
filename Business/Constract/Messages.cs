using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constract
{
    public static class Messages
    {
        public static string Added = "Ekleme Islemi Basarili";
        public static string Deleted = "Silme Islemi Basarili";
        public static string Updated = "Guncelleme Islemi Basarili";
        public static string Listed = "Listeleme Islemi Basarili";
        public static string Delivered="Teslim Etme Islemi Basarili";

        public static string NotAdded = "Ekleme Islemi Yapilirken Bir Hata Ile Karsilasildi!";
        public static string NotDeleted = "Silme Islemi Yapilirken Bir Hata Ile Karsilasildi!";
        public static string NotUpdated = "Guncelleme Islemi Yapilirken Bir Hata Ile Karsilasildi!";
        public static string NotListed = "Listeleme Islemi Yapilirken Bir Hata Ile Karsilasildi!";
        public static string Full = "Secitiginiz Arac Musteride Oldugundan Size Teslim Edemiyoruz";
        public static string NotDelivered = "Teslim Etme Islemi Yapilirken Bir Hata Ile Karsilasildi!";
    }
}
