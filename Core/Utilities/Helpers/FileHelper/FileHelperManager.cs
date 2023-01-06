using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers.GuidHelperr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
  
    public class FileHeplerManager : IFileHelper
    {
        public void Delete(string filePath)//Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı 
        {
            if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }

        public string Update(IFormFile file, string filePath, string root)//Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        {
            if (File.Exists(filePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }

        //IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
        //FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)//file.Length=>Dosya uzunluğunu bayt olarak alır.
            {
                if (!Directory.Exists(root))//Directory=>System.IO'nın bir class'ı.
                {
                    //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* gelir.
                    Directory.CreateDirectory(root);
                    //Dosya kaydedilecek yerdir.Belirtilen yerde dosya yoksa olustur
                }
                string extension = Path.GetExtension(file.FileName);//Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string guid = GuidHelper.CreateGuid();//Core.Utilities.Helpers.GuidHelper ile essiz guild olusturuyoruz.
                string filePath = guid + extension;//Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum.

                using (FileStream fileStream = File.Create(root + filePath))//Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
                {
                    file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                    fileStream.Flush();//arabellekten siler.
                    return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }
            }
            return null;
        }
    }
}
