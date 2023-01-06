using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string carsBrandOutOfRange= "Maksimum Ayni Markadan 10 Arac Bulunabilir";
        public static string brandNameExist = "Eklemeye Calistiginiz Marka Sistemde Bulunmaktadir";
        public static string ArriveBrandCountLimitToAddedCar = "Araba Eklemek icin Marka Sinirina Ulasildi Benim Ekledigim Kural Egitim Amacli";
        public static string ColorExists = "Eklemeye Calistiginiz Renk Sistemde Bulunmaktadir";
        public static string EmailAlreadyExists = "Email Sistemde Zaten Kayitli";
        public static string SelectedCardIdNotExists = "Secilen Araba Id si mevcut degildir.";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserRegistered="Kayit Islemi Basarili";
        public static string UserNotFound="Kullanici Bulunamadi";
        public static string PasswordError="Sifre Hatali";
        public static string SuccessfulLogin = "Giris Basarili";
        public static string AccessTokenCreated = "Giris Jetonu Olusturuldu";
    }
}
